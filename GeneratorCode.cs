using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CNC_Controller
{
    public partial class GeneratorCode : Form
    {

        private MainForm mf;

        private string code = "";

        public List<primitivNode> ConstructorNodes = new List<primitivNode>();

        public GeneratorCode(MainForm _mf)
        {
            mf = _mf;
            InitializeComponent();
        }


        #region Добавление новых примитивов




        public primitivNode findIncludeGUID(primitivNode _node, string _guid)
        {
            primitivNode result = null;

            if (_node.GUID == _guid) return _node;

            foreach (primitivNode VARIABLE in _node.nodes)
            {
                if (VARIABLE.GUID == _guid) return VARIABLE;

                //так-же запустим поиск внутри подчиненных узлов
                primitivNode ppn = findIncludeGUID(VARIABLE, _guid);

                if (ppn != null) return ppn;
            }
            return result;
        }

        public primitivNode FindNodeToGUID(string _GUID)
        {
            primitivNode result = null;

            foreach (primitivNode VARIABLE1 in ConstructorNodes)
            {
                if (VARIABLE1.GUID == _GUID) return VARIABLE1;

                //так-же запустим поиск внутри подчиненных узлов
                primitivNode ppn = findIncludeGUID(VARIABLE1, _GUID);

                if (ppn != null) return ppn;
            }
            return result;
        }

        // Добавление каталога в дерево
        public void AddNewCatalog(TreeNode _treeNode)
        {
            // элемент из ConstructorNodes
            primitivNode pnfind = null;

            if (_treeNode != null)
            {
                pnfind = FindNodeToGUID(_treeNode.Name);
            }

            // Сразу проверим узел выше, т.к. каталог можно создавать в корне дерева, или внутри другого каталога, а создание каталога внутри других элементов нельзя
            if (pnfind != null)
            {
                if (pnfind.typeNode != primitivType.catalog)
                    MessageBox.Show("Создание каталога возможно только в корне, или внутри другого каталога!");
                return;
            }

            primitivNode pn = new primitivNode(new primitivCatalog(0, 0, 0));

            if (pnfind == null) ConstructorNodes.Add(pn);
            else pnfind.nodes.Add(pn);

            TreeNodeCollection resultNode = null; // коллекция узлов в который добавим новый узел группы

            if (_treeNode == null)
            {
                //находимся в самой верхушке иерархии дерева
                resultNode = treeDataConstructor.Nodes;
            }
            else
            {
                //есть родитель выше
                resultNode = _treeNode.Nodes;
            }

            resultNode.Add(pn.GUID, "catalog", 1);
        }

        // Добавление новой точки в дерево
        public void AddNewPoint(TreeNode _treeNode)
        {
            if (_treeNode == null)
            {
                treeDataConstructor.Nodes.Add("Point", "Point", 2);
            }
            else
            {
                _treeNode.Nodes.Add("Point", "Point", 2);
            }
        }

        // Добавление новой линии в дерево
        public void AddNewLine(TreeNode _treeNode)
        {
            if (_treeNode == null)
            {
                TreeNode tr = treeDataConstructor.Nodes.Add("Line", "Line", 3);
                AddNewPoint(tr);
                AddNewPoint(tr);
            }
            else
            {

                TreeNode tr = _treeNode.Nodes.Add("Line", "Line", 3);
                // т.к. линия это набор из точек
                AddNewPoint(tr);
                AddNewPoint(tr);
            }


        }

        #endregion






        #region Элементы формы добавления данных

        private void btNewData_Click(object sender, EventArgs e)
        {
            //TODO: Если есть данные, то спросить о необходимости сохранения данных в файл

            treeDataConstructor.Nodes.Clear();
        }

        // добавление группы
        private void btAddCatalog_Click(object sender, EventArgs e)
        {
            // Добавление группы элементов
            AddNewCatalog(treeDataConstructor.SelectedNode);
        }
        private void toolStripMenuAddGroupe_Click(object sender, EventArgs e)
        {
            AddNewCatalog(treeDataConstructor.SelectedNode);
        }
        // добавление новой точки
        private void btAddPoint_Click(object sender, EventArgs e)
        {
            AddNewPoint(treeDataConstructor.SelectedNode);
        }
        private void toolStripMenuAddPoint_Click(object sender, EventArgs e)
        {
            AddNewPoint(treeDataConstructor.SelectedNode);
        }
        // добавление линии
        private void btAddLine_Click(object sender, EventArgs e)
        {
            AddNewLine(treeDataConstructor.SelectedNode);
        }
        private void toolStripMenuAddLine_Click(object sender, EventArgs e)
        {
            AddNewLine(treeDataConstructor.SelectedNode);
        }

        #endregion
 
    




















        //Генерация, и посылка новых данных
        private void RefreshData()
        {
            string code = "";

            // 1. прямолинейное движение к начальной точке
            code += "G0 X" + numPosX.Value.ToString() + " Y" + numPosY.Value.ToString() + "\n";
            code += "G1 Z" + numPosZ.Value.ToString() + "\n";

            // 2. движение змейкой


            bool toLeft = true; // направление движения змейки


            int countTask = (int)numericUpDown1.Value + 1;

            decimal posZ = numPosZ.Value;

            while (countTask > 0)
            {


                decimal posYNow = numPosY.Value;
                decimal posYMax = numPosY.Value + numericUpDownSizeY.Value;
                decimal posXMax = numPosX.Value + numericUpDownSizeX.Value;


                while (posYNow != posYMax)
                {
                    if (toLeft)
                    {
                        toLeft = false;
                        code += "G1 X" + posXMax.ToString() + "\n";
                    }
                    else
                    {
                        toLeft = true;
                        code += "G1 X" + numPosX.Value.ToString() + "\n";
                    }

                    if ((posYNow + numericUpDownDelta.Value) > (numPosY.Value + numericUpDownSizeY.Value))
                    {
                        posYNow = posYMax;
                    }
                    else
                    {
                        posYNow += numericUpDownDelta.Value;
                    }

                    code += "G1 Y" + posYNow.ToString() + "\n";
                }


                if (toLeft)
                {
                    code += "G1 X" + posXMax.ToString() + "\n";
                }
                else
                {
                    code += "G1 X" + numPosX.Value.ToString() + "\n";
                }

                posZ -= numericUpDown2.Value;

                code += "G0 Z" + posZ + "\n";



                countTask--;
            }




            //for (decimal y = numPosY.Value; y < (numPosY.Value + numericUpDownSizeY.Value); y += numericUpDownDelta.Value)
            //{

            //    

            //    //





            //}




            if (radioButton2.Checked)
            {
                // 3. Поднятие вверх
                code += "G0 Z" + numericUpDown3.Value.ToString() + "\n";
            }

            //пошлем сгенерированный код
            mf.LoadDataFromText(Regex.Split(code, "\n"));
        }




        private void GeneratorCode_Load(object sender, EventArgs e)
        {

        }

        private void buttonGenerateCode_Click(object sender, EventArgs e)
        {
            RefreshData();

        }

        private void treeDataConstructor_Click(object sender, EventArgs e)
        {
            // что-бы не менялся значек
            //if (treeDataConstructor.SelectedNode != null)
            //{
            //    //treeDataConstructor.SelectedImageIndex = treeDataConstructor.SelectedNode.ImageIndex;
            //}
        }

        private void treeDataConstructor_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // что-бы не менялся значек
            if (treeDataConstructor.SelectedNode != null)
            {
                treeDataConstructor.SelectedImageIndex = treeDataConstructor.SelectedNode.ImageIndex;
            }
        }

    }
}



public class primitivCatalog
{
    public double X;       // координата в мм
    public double Y;       // координата в мм
    public double Z;       // координата в мм

    public primitivCatalog(double _x, double _y, double _z)
    {
        X = _x;
        Y = _y;
        Z = _z;
    }

}


/// <summary>
/// Примитив точка
/// </summary>
public class primitivPoint
{
    public double X;       // координата в мм
    public double Y;       // координата в мм
    public double Z;       // координата в мм

    public primitivPoint(double _x, double _y, double _z)
    {
        X = _x;
        Y = _y;
        Z = _z;
    }

}

/// <summary>
/// Примитив линия
/// </summary>
public class primitivLine
{
    public primitivPoint point1;       
    public primitivPoint point2;   

    public primitivLine(primitivPoint _p1, primitivPoint _p2)
    {
        point1 = _p1;
        point2 = _p2;
    }
}



public enum primitivType
{
    catalog,
    point,
    line
}


/// <summary>
/// Класс для хранения данных, конструктора
/// </summary>
public class primitivNode
{
    public string GUID;
    public primitivType typeNode;
    public primitivCatalog catalog;
    public primitivPoint point;
    public primitivLine line;
    public List<primitivNode> nodes;

    public primitivNode(primitivCatalog _catalog)
    {
        GUID = Guid.NewGuid().ToString();
        typeNode = primitivType.catalog;
        catalog = _catalog;
        point = null;
        line = null;
        nodes = new List<primitivNode>();
    }

    public primitivNode(primitivPoint _point)
    {
        GUID = Guid.NewGuid().ToString();
        typeNode = primitivType.point;
        catalog = null;
        point = _point;
        line = null;
        nodes = new List<primitivNode>();
    }

    public primitivNode(primitivLine _line)
    {
        GUID = Guid.NewGuid().ToString();
        typeNode = primitivType.line;
        catalog = null;
        point = null;
        line = _line;
        nodes = new List<primitivNode>();
    }




    



}