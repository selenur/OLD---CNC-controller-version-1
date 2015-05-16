using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CNC_Controller
{
    public partial class GeneratorCode : Form
    {

        private MainForm mf;

        private string code = "";

        public GeneratorCode(MainForm _mf)
        {
            mf = _mf;
            InitializeComponent();
        }


        #region Добавление новых примитивов

        // Добавление каталога в дерево
        public void AddNewCatalog(TreeNode _treeNode)
        {
            TreeNodeCollection resultNode = null; // коллекция узлов в который добавим новый узел группы

            if (_treeNode == null) resultNode = treeDataConstructor.Nodes;
            else resultNode = _treeNode.Nodes;

            //TODO: проверим родителя, т.к. родителем не может быть примитив


            resultNode.Add("catalog", "catalog", 1);



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