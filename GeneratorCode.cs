using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CNC_Controller.primitiv;

namespace CNC_Controller
{
    public partial class GeneratorCode : Form
    {
        /// <summary>
        /// Ссылка на основную форму
        /// </summary>
        private MainForm mf;

        /// <summary>
        /// текст G-кода формируемого конструктором
        /// </summary>
        private string Gcode = "";

        /// <summary>
        /// Список примитивов
        /// </summary>
        public List<primitivNode> ListPrimitives = new List<primitivNode>();

        public GeneratorCode(MainForm _mf)
        {
            mf = _mf;
            InitializeComponent();
        }


        #region Добавление новых примитивов



        // Рекурсивный поиск внутри примитивов, других примитивов
        public primitivNode findNodeWithGUID(string _guid, primitivNode _node = null)
        {
            primitivNode result = null;

            primitivNode RootNode = _node;

            if (RootNode == null) RootNode = ListPrimitives[0];

            if (RootNode.GUID == _guid) return RootNode;

            foreach (primitivNode VARIABLE in RootNode.nodes)
            {
                if (VARIABLE.GUID == _guid) return VARIABLE;

                //так-же запустим поиск внутри подчиненных узлов
                primitivNode ppn = findNodeWithGUID(_guid,VARIABLE);

                if (ppn != null) return ppn;
            }
            return result;
        }

        // Добавление новой группы в "дерево данных"
        public void AddNewGroup()
        {
            TreeNode pNode = treeDataConstructor.SelectedNode;

            // попытаемся получить вышестоящий узел в дереве
            if (pNode == null) pNode = treeDataConstructor.Nodes[0];

            if (pNode == null) // всетаки неудалось.......
            {
                MessageBox.Show(@"DANGER!!! Ошибка указания родителя?!?!");
                return;
            }

            // найдем вышестоящий узел в ListPrimitives
            primitivNode pnfind = findNodeWithGUID(pNode.Name);

            if (pnfind == null)
            {
                MessageBox.Show(@"DANGER!!! Ошибка поиска родителя?!?!");
                return;
            }

            // Сразу проверим узел выше, т.к. каталог можно создавать в корне дерева, или внутри другого каталога, а создание каталога внутри других элементов нелогично
            if (pnfind.typeNode != primitivType.catalog)
            {
                MessageBox.Show(@"Создание каталога в нутри данного примитива невозможно!");
                return;                
            }

            // вызовем диалог добавления группы
            frmCatalog fCatalog = new frmCatalog();

            DialogResult dlResult = fCatalog.ShowDialog();

            if (dlResult == DialogResult.OK)
            {
                primitivNode pn = new primitivNode(new primitivGroup((double)fCatalog.numPosX.Value, (double)fCatalog.numPosY.Value, (double)fCatalog.numPosZ.Value,fCatalog.textBoxName.Text,fCatalog.cbAllowPoint.Checked));
                pnfind.nodes.Add(pn);
                pNode.Nodes.Add(pn.GUID, fCatalog.textBoxName.Text, 1).Expand();
            }
            
            treeDataConstructor.ExpandAll();
        }

        // Добавление новой точки в дерево
        public void AddNewPoint(TreeNode _treeNode)
        {
            TreeNode pNode = _treeNode;

            // попытаемся найти первый нод в дереве
            if (pNode == null) pNode = treeDataConstructor.Nodes[0];

            if (pNode == null) // всетаки неудалось.......
            {
                MessageBox.Show(@"DANGER!!! Ошибка указания родителя?!?!");
                return;
            }

            //pNode.Expand();

            // элемент который будем искать в ListPrimitives (ПОИСК РОДИТЕЛЬСКОГО ЭЛЕМЕНТА)
            primitivNode pnfind = findNodeWithGUID(_treeNode.Name);

            if (pnfind == null)
            {
                MessageBox.Show(@"DANGER!!! Ошибка поиска родителя?!?!");
                return;
            }

            // Сразу проверим узел выше, т.к. точку внутри точки создавать нелогично
            if (pnfind.typeNode == primitivType.point || pnfind.typeNode == primitivType.line)
            {
                MessageBox.Show(@"Создание точки в нутри данного примитива невозможно!");
                return;
            }

            primitivNode pn = new primitivNode(new primitivPoint(0, 0, 0));

            pnfind.nodes.Add(pn);

            pNode.Nodes.Add(pn.GUID, "point", 2).Expand();

            treeDataConstructor.ExpandAll();
        }

        // Добавление новой линии в дерево
        public void AddNewLine(TreeNode _treeNode)
        {
            TreeNode pNode = _treeNode;

            // попытаемся найти первый нод в дереве
            if (pNode == null) pNode = treeDataConstructor.Nodes[0];

            if (pNode == null) // всетаки неудалось.......
            {
                MessageBox.Show(@"DANGER!!! Ошибка указания родителя?!?!");
                return;
            }

            //pNode.Expand();

            // элемент который будем искать в ListPrimitives (ПОИСК РОДИТЕЛЬСКОГО ЭЛЕМЕНТА)
            primitivNode pnfind = findNodeWithGUID(_treeNode.Name);

            if (pnfind == null)
            {
                MessageBox.Show(@"DANGER!!! Ошибка поиска родителя?!?!");
                return;
            }

            // Сразу проверим узел выше, т.к. линию можно создавать в корне дерева, или внутри другого каталога, а создание линии внутри других элементов нелогично
            if (pnfind.typeNode != primitivType.catalog)
            {
                MessageBox.Show(@"Создание линии возможно только в корне, или внутри другого каталога!");
                return;
            }

            //точки у линии
            primitivPoint pp1 = new primitivPoint(0, 0, 0);
            primitivPoint pp2 = new primitivPoint(1,1,1);

            primitivLine pline = new primitivLine(pp1,pp2);

            primitivNode pn = new primitivNode(pline);

            //pn.nodes.Add(new primitivNode(new primitivPoint(0,0,0)));

            pnfind.nodes.Add(pn);

            pNode.Nodes.Add(pn.GUID, "line", 3).Expand();

            treeDataConstructor.ExpandAll();



            //TreeNode tr = resultNode.Add(pn.GUID, "Line", 3);
            //AddNewPoint(tr);
            //AddNewPoint(tr);


            //if (_treeNode == null)
            //{
            //    TreeNode tr = treeDataConstructor.Nodes.Add("Line", "Line", 3);
            //    AddNewPoint(tr);
            //    AddNewPoint(tr);
            //}
            //else
            //{

            //    TreeNode tr = _treeNode.Nodes.Add("Line", "Line", 3);
            //    // т.к. линия это набор из точек
            //    AddNewPoint(tr);
            //    AddNewPoint(tr);
            //}


        }

        #endregion






        #region Элементы формы добавления данных


        private void Clear_Tree()
        {
            treeDataConstructor.Nodes.Clear();

            ListPrimitives.Clear();

            primitivNode pp = new primitivNode(new primitivGroup(0, 0, 0));
            ListPrimitives.Add(pp);

            treeDataConstructor.Nodes.Add(pp.GUID, "Точка старта", 0);
        }

        private void btNewData_Click(object sender, EventArgs e)
        {
            //TODO: Если есть данные, то спросить о необходимости сохранения данных в файл

            Clear_Tree();
        }

        // добавление группы
        private void btAddCatalog_Click(object sender, EventArgs e)
        {
            // Добавление группы элементов
            AddNewGroup();
        }
        private void toolStripMenuAddGroupe_Click(object sender, EventArgs e)
        {
            AddNewGroup();
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
            Clear_Tree();
        }

        private void buttonGenerateCode_Click(object sender, EventArgs e)
        {
            RefreshData();

        }

        private void treeDataConstructor_Click(object sender, EventArgs e)
        {
            treeDataConstructor.ExpandAll();
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

        private void treeDataConstructor_DoubleClick(object sender, EventArgs e)
        {
            //открытие диалога примитива, тут
            //MessageBox.Show(treeDataConstructor.SelectedNode.Name);

            //получим примитив по гуиду
            primitivNode pfind = findNodeWithGUID(treeDataConstructor.SelectedNode.Name);
            //определим его тип, и откроем необходимый диалог

            if (pfind.typeNode == primitivType.catalog)
            {
                // вызовем диалог добавления группы
                frmCatalog fCatalog = new frmCatalog();
                fCatalog.numPosX.Value = (decimal)pfind.catalog.X;
                fCatalog.numPosY.Value = (decimal)pfind.catalog.Y;
                fCatalog.numPosZ.Value = (decimal)pfind.catalog.Z;
                fCatalog.textBoxName.Text = pfind.catalog.Name;
                fCatalog.cbAllowPoint.Checked = pfind.catalog.AllowPoint;

                DialogResult dlResult = fCatalog.ShowDialog();

                if (dlResult == DialogResult.OK)
                {
                    pfind.catalog.X = (double)fCatalog.numPosX.Value;
                    pfind.catalog.Y = (double)fCatalog.numPosY.Value;
                    pfind.catalog.Z = (double)fCatalog.numPosZ.Value;
                    pfind.catalog.Name = fCatalog.textBoxName.Text;
                    pfind.catalog.AllowPoint = fCatalog.cbAllowPoint.Checked;
                }
            }




        }

    }
}

// ПЕРЕЗАПОЛНЕНИЕ ДЕРЕВА БЕЗ ПЕРЕРИСОВКИ

////////////////// Populates a TreeView control with example nodes. 
////////////////private void InitializeTreeView()
////////////////{
////////////////    treeView1.BeginUpdate();
////////////////    treeView1.Nodes.Add("Parent");
////////////////    treeView1.Nodes[0].Nodes.Add("Child 1");
////////////////    treeView1.Nodes[0].Nodes.Add("Child 2");
////////////////    treeView1.Nodes[0].Nodes[1].Nodes.Add("Grandchild");
////////////////    treeView1.Nodes[0].Nodes[1].Nodes[0].Nodes.Add("Great Grandchild");
////////////////    treeView1.EndUpdate();
////////////////}


/// <summary>
/// Класс описания группы элементов
/// </summary>
public class primitivGroup
{
    public double X;       // координата в мм
    public double Y;       // координата в мм
    public double Z;       // координата в мм
    public string Name;   // для представления
    public bool AllowPoint; // необходимость учитывать данную точку

    public primitivGroup(double _x, double _y, double _z, string _name = "Группа", bool _allowPoint = false)
    {
        X = _x;
        Y = _y;
        Z = _z;
        Name = _name;
        AllowPoint = _allowPoint;
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
    public primitivGroup catalog;
    public primitivPoint point;
    public primitivLine line;
    public List<primitivNode> nodes;

    public primitivNode(primitivGroup _catalog)
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