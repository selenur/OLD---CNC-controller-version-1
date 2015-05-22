using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CNC_Controller.ConstructorGkode;
using CNC_Controller.primitiv;

namespace CNC_Controller
{
    public partial class GeneratorCode : Form
    {
        /// <summary>
        /// Ссылка на основную форму
        /// </summary>
        private readonly MainForm _mf;

        // последняя координата, при добавлении примитива
        private double _lastX;       // координата в мм
        private double _lastY;       // координата в мм
        private double _lastZ;       // координата в мм


        /// <summary>
        /// Список примитивов
        /// </summary>
        private List<primitivNode> _listPrimitives = new List<primitivNode>();

        #region Элементы формы добавления данных

        private void GeneratorCode_Load(object sender, EventArgs e)
        {
            _listPrimitives.Clear();
            RefreshTree();
        }

        public GeneratorCode(MainForm _mf)
        {
            this._mf = _mf;
            InitializeComponent();
        }

        private void btNewData_Click(object sender, EventArgs e)
        {
            _listPrimitives.Clear();
            RefreshTree();
        }


        private void toolStripMenuAddGroupe_Click(object sender, EventArgs e)
        {
            AddNewGroup();
        }

        private void toolStripMenuAddPoint_Click(object sender, EventArgs e)
        {
            AddNewPoint();
        }

        private void treeDataConstructor_Click(object sender, EventArgs e)
        {
            //treeDataConstructor.ExpandAll();
        }

        private void treeDataConstructor_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // что-бы не менялся значек
            if (treeDataConstructor.SelectedNode != null)
            {
                treeDataConstructor.SelectedImageIndex = treeDataConstructor.SelectedNode.ImageIndex;
            }
        }


        #endregion
 
        #region Добавление новых примитивов

        // Рекурсивный поиск внутри примитивов, других примитивов
        public primitivNode findNodeWithGUID(string _guid, primitivNode _node = null)
        {
            primitivNode result = null;

            primitivNode RootNode = _node;

            if (RootNode == null) RootNode = _listPrimitives[0];

            if (RootNode.GUID == _guid) return RootNode;

            foreach (primitivNode VARIABLE in RootNode.nodes)
            {
                if (VARIABLE.GUID == _guid) return VARIABLE;

                //так-же запустим поиск внутри подчиненных узлов
                primitivNode ppn = findNodeWithGUID(_guid, VARIABLE);

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
            if (!(pnfind.typeNode == primitivType.catalog || pnfind.typeNode == primitivType.cycler))
            {
                MessageBox.Show(@"Создание каталога в нутри данного примитива невозможно!");
                return;
            }

            // вызовем диалог добавления группы
            frmCatalog fCatalog = new frmCatalog(_mf);
            fCatalog.numPosX.Value = (decimal)_lastX;
            fCatalog.numPosY.Value = (decimal)_lastY;
            fCatalog.numPosZ.Value = (decimal)_lastZ;

            DialogResult dlResult = fCatalog.ShowDialog();

            if (dlResult == DialogResult.OK)
            {
                _lastX = (double)fCatalog.numPosX.Value;
                _lastY = (double)fCatalog.numPosY.Value;
                _lastZ = (double)fCatalog.numPosZ.Value;

                primitivNode pn = new primitivNode(new primitivGroup((double)fCatalog.numPosX.Value, (double)fCatalog.numPosY.Value, (double)fCatalog.numPosZ.Value, fCatalog.textBoxName.Text, fCatalog.cbAllowPoint.Checked));
                pnfind.nodes.Add(pn);
                RefreshTree();
            }
        }

        // Добавление новой точки в дерево
        public void AddNewPoint()
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

            // Сразу проверим узел выше, т.к. точку внутри точки создавать нелогично
            if (pnfind.typeNode == primitivType.point)
            {
                MessageBox.Show(@"Создание точки в нутри данного примитива невозможно!");
                return;
            }

            frmPoint fPoint = new frmPoint();
            fPoint.numPosX.Value = (decimal)_lastX;
            fPoint.numPosY.Value = (decimal)_lastY;
            fPoint.numPosZ.Value = (decimal)_lastZ;

            DialogResult dlResult = fPoint.ShowDialog();

            if (dlResult == DialogResult.OK)
            {
                _lastX = (double)fPoint.numPosX.Value;
                _lastY = (double)fPoint.numPosY.Value;
                _lastZ = (double)fPoint.numPosZ.Value;

                primitivNode pn = new primitivNode(new primitivPoint((double)fPoint.numPosX.Value, (double)fPoint.numPosY.Value, (double)fPoint.numPosZ.Value));
                pnfind.nodes.Add(pn);
                RefreshTree();
            }
        }


        public void AddNewCycle()
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

            // Сразу проверим узел выше, т.к. Циклёр можно создавать в корне дерева, или внутри другого каталога, а создание Циклёра внутри других элементов нелогично
            if (!(pnfind.typeNode == primitivType.catalog || pnfind.typeNode == primitivType.cycler))
            {
                MessageBox.Show(@"Создание циклёра в нутри данного примитива невозможно!");
                return;
            }

            // вызовем диалог добавления циклёра
            frmCycler fCycler = new frmCycler(_mf);

            DialogResult dlResult = fCycler.ShowDialog();

            if (dlResult == DialogResult.OK)
            {
                primitivNode pn = new primitivNode(new primitivCycle((double)fCycler.numStart.Value, (double)fCycler.numStop.Value, (double)fCycler.numStep.Value, fCycler.cbX.Checked, fCycler.cbY.Checked, fCycler.cbZ.Checked, fCycler.textBoxName.Text));
                pnfind.nodes.Add(pn);
                RefreshTree();
            }

        }


        #endregion


        private void OpenFormDialog()
        {

            // Необходимость перезаполнения дерева обновленными данными
            bool NeedRefreshTree = false;

            //получим примитив по гуиду
            primitivNode pfind = findNodeWithGUID(treeDataConstructor.SelectedNode.Name);
            //определим его тип, и откроем необходимый диалог

            if (pfind.typeNode == primitivType.catalog)
            {
                // вызовем диалог добавления группы
                frmCatalog fCatalog = new frmCatalog(_mf);
                fCatalog.numPosX.Value = (decimal)pfind.catalog.X;
                fCatalog.numPosY.Value = (decimal)pfind.catalog.Y;
                fCatalog.numPosZ.Value = (decimal)pfind.catalog.Z;
                fCatalog.textBoxName.Text = pfind.catalog.Name;
                fCatalog.cbAllowPoint.Checked = pfind.catalog.AllowDelta;

                DialogResult dlResult = fCatalog.ShowDialog();

                if (dlResult == DialogResult.OK)
                {
                    pfind.catalog.X = (double)fCatalog.numPosX.Value;
                    pfind.catalog.Y = (double)fCatalog.numPosY.Value;
                    pfind.catalog.Z = (double)fCatalog.numPosZ.Value;
                    pfind.catalog.Name = fCatalog.textBoxName.Text;
                    pfind.catalog.AllowDelta = fCatalog.cbAllowPoint.Checked;

                    NeedRefreshTree = true;
                }
            }

            if (pfind.typeNode == primitivType.cycler)
            {
                // вызовем диалог добавления группы
                frmCycler fCycler = new frmCycler(_mf);

                fCycler.numStart.Value = (decimal)pfind.cycler.cStart;
                fCycler.numStop.Value = (decimal)pfind.cycler.cStop;
                fCycler.numStep.Value = (decimal)pfind.cycler.cStep;
                fCycler.textBoxName.Text = pfind.cycler.Name;
                fCycler.cbX.Checked = pfind.cycler.AllowDeltaX;
                fCycler.cbY.Checked = pfind.cycler.AllowDeltaY;
                fCycler.cbZ.Checked = pfind.cycler.AllowDeltaZ;

                DialogResult dlResult = fCycler.ShowDialog();

                if (dlResult == DialogResult.OK)
                {
                    pfind.cycler.cStart = (double)fCycler.numStart.Value;
                    pfind.cycler.cStop = (double)fCycler.numStop.Value;
                    pfind.cycler.cStep = (double)fCycler.numStep.Value;

                    pfind.cycler.Name = fCycler.textBoxName.Text;
                    pfind.cycler.AllowDeltaX = fCycler.cbX.Checked;
                    pfind.cycler.AllowDeltaY = fCycler.cbY.Checked;
                    pfind.cycler.AllowDeltaZ = fCycler.cbZ.Checked;

                    NeedRefreshTree = true;
                }
            }


            if (pfind.typeNode == primitivType.point)
            {
                // вызовем диалог добавления группы
                frmPoint fPoint = new frmPoint();
                fPoint.numPosX.Value = (decimal)pfind.point.X;
                fPoint.numPosY.Value = (decimal)pfind.point.Y;
                fPoint.numPosZ.Value = (decimal)pfind.point.Z;

                DialogResult dlResult = fPoint.ShowDialog();

                if (dlResult == DialogResult.OK)
                {
                    pfind.point.X = (double)fPoint.numPosX.Value;
                    pfind.point.Y = (double)fPoint.numPosY.Value;
                    pfind.point.Z = (double)fPoint.numPosZ.Value;
                    NeedRefreshTree = true;
                }
            }

            if (NeedRefreshTree) RefreshTree();
        }


        // Открытие диалогов у существующих примитивов
        private void treeDataConstructor_DoubleClick(object sender, EventArgs e)
        {
            OpenFormDialog();
        }

        // рекурсивная функция для перерисовки дерева
        private void DrawPrimitivInTree(primitivNode _primitivNode, TreeNode _rootNode = null)
        {
            TreeNode trNode = null;

            if (_rootNode == null)
            {
                trNode = treeDataConstructor.Nodes.Add("");
            }
            else
            {
                trNode = _rootNode.Nodes.Add("");
            }

            if (_primitivNode.typeNode == primitivType.catalog)
            {
                trNode.ImageIndex = 1;
                trNode.Name = _primitivNode.GUID;
                trNode.Text = _primitivNode.catalog.Name;
            }

            if (_primitivNode.typeNode == primitivType.cycler)
            {
                trNode.ImageIndex = 4;
                trNode.Name = _primitivNode.GUID;

                trNode.Text = _primitivNode.cycler.Name + "(с: " + _primitivNode.cycler.cStart + " по: " + _primitivNode.cycler.cStop + " шаг:" + +_primitivNode.cycler.cStep +")";
            }

            if (_primitivNode.typeNode == primitivType.point)
            {
                trNode.ImageIndex = 2;
                trNode.Name = _primitivNode.GUID;
                trNode.Text = "Точка: (" + _primitivNode.point.X + ", " + _primitivNode.point.Y + ", "  + _primitivNode.point.Z + ")";
            }

            if (_primitivNode.nodes.Count == 0) return;

            foreach (primitivNode VARIABLE in _primitivNode.nodes)
                DrawPrimitivInTree(VARIABLE, trNode);
        }
        
        // перерисовка данных
        private void RefreshTree()
        {
            //элемент на котом нужно будет спозиционироваться
            string GUIDselectedNode = "";

            if (treeDataConstructor.SelectedNode != null) GUIDselectedNode = treeDataConstructor.SelectedNode.Name;

            treeDataConstructor.Nodes.Clear();

            //Если нет данных
            if (_listPrimitives.Count == 0)
            {
                primitivNode pp = new primitivNode(new primitivGroup(0, 0, 0, "Точка старта"));
                _listPrimitives.Add(pp);
                GUIDselectedNode = pp.GUID;
            }

            treeDataConstructor.BeginUpdate();
            treeDataConstructor.Nodes.Clear();

            DrawPrimitivInTree(_listPrimitives[0]);

            treeDataConstructor.EndUpdate();
            treeDataConstructor.ExpandAll();

            // и G-код сразу сгенерируем
            CREATE_GKOD();


            // установим активность на узле с GUIDselectedNode
            TreeNode[] trArray = treeDataConstructor.Nodes.Find(GUIDselectedNode, true);

            if (trArray.Length != 0) treeDataConstructor.SelectedNode = trArray[0];


        }

        private void ParsePrimitivesToGkode(ref string _strCode, primitivNode _node, double deltaX = 0, double deltaY = 0, double deltaZ = 0)
        {
            if (_node.typeNode == primitivType.point)
            {
                _strCode += "G1 X" + (_node.point.X + deltaX) + " Y" + (_node.point.Y + deltaY) + " Z" + (_node.point.Z + deltaZ) + "\n";
                return;
            }


            if (_node.typeNode == primitivType.catalog)
            {
                double dX = deltaX;       // координата в мм
                double dY = deltaY;       // координата в мм
                double dZ = deltaZ;       // координата в мм

                if (_node.catalog.AllowDelta)
                {
                    dX += _node.catalog.X;
                    dY += _node.catalog.Y;
                    dZ += _node.catalog.Z;
                }

                foreach (primitivNode VARIABLE in _node.nodes)
                {
                    ParsePrimitivesToGkode(ref _strCode,VARIABLE,dX,dY,dZ);
                }
            }



            if (_node.typeNode == primitivType.cycler)
            {
                if (_node.cycler.cStart < _node.cycler.cStop)
                {
                    for (double i = _node.cycler.cStart; i < _node.cycler.cStop; i += _node.cycler.cStep)
                    {
                    
                        double dX = deltaX;       // координата в мм
                        double dY = deltaY;       // координата в мм
                        double dZ = deltaZ;       // координата в мм

                        if (_node.cycler.AllowDeltaX) dX += i;

                        if (_node.cycler.AllowDeltaY) dY += i;

                        if (_node.cycler.AllowDeltaZ) dZ += i;
                    
                        foreach (primitivNode VARIABLE in _node.nodes)
                        {
                            ParsePrimitivesToGkode(ref _strCode, VARIABLE, dX, dY, dZ);
                        }
                    }    
                }
                else
                {
                    for (double i = _node.cycler.cStart; i > _node.cycler.cStop; i -= _node.cycler.cStep)
                    {

                        double dX = deltaX;       // координата в мм
                        double dY = deltaY;       // координата в мм
                        double dZ = deltaZ;       // координата в мм

                        if (_node.cycler.AllowDeltaX) dX += i;

                        if (_node.cycler.AllowDeltaY) dY += i;

                        if (_node.cycler.AllowDeltaZ) dZ += i;

                        foreach (primitivNode VARIABLE in _node.nodes)
                        {
                            ParsePrimitivesToGkode(ref _strCode, VARIABLE, dX, dY, dZ);
                        }
                    }
                }
            }
        }

        private void CREATE_GKOD()
        {
            string code = "";

            if (_listPrimitives.Count == 0) return;

            ParsePrimitivesToGkode(ref code, _listPrimitives[0]);

            //пошлем сгенерированный код
            _mf.LoadDataFromText(Regex.Split(code, "\n"));
        }

        private void DeleteNode(string _GUID, primitivNode _primitiv)
        {
            foreach (primitivNode VARIABLE in _primitiv.nodes)
            {
                if (VARIABLE.GUID == _GUID)
                {
                    _primitiv.nodes.Remove(VARIABLE);
                    break; //дальше продолжать нельзя, т.к. сломали выборку
                }
                else DeleteNode(_GUID, VARIABLE);
            }
        }

        private void delPrimitivToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeDataConstructor.SelectedNode == null) return;

            if (MessageBox.Show("Удалить выделенный примитив?","Удаление",MessageBoxButtons.OKCancel) != DialogResult.OK) return;

            DeleteNode(treeDataConstructor.SelectedNode.Name, _listPrimitives[0]);

            RefreshTree();
        }

        private void openDialogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormDialog();
        }

        private void btSaveToFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = @"Данные конструктора (*.dat)|*.dat|Все файлы (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                BinaryFormatter binFormat = new BinaryFormatter();
                using (Stream fStream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    binFormat.Serialize(fStream, _listPrimitives[0]);
                }
            }
        }

        private void btLoadFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Данные конструктора (*.dat)|*.dat|Все файлы (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                BinaryFormatter binFormat = new BinaryFormatter();

                using (Stream fStream = File.OpenRead(openFileDialog1.FileName))
                {
                    primitivNode pNode = (primitivNode)binFormat.Deserialize(fStream);
                    _listPrimitives[0] = pNode;
                }
                RefreshTree();
            }
        }

        private void treeDataConstructor_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddNewGroup();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AddNewPoint();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AddNewCycle();
        }
    }
}




/// <summary>
/// Класс описания группы элементов
/// </summary>
[Serializable]
public class primitivGroup
{
    public double X;       // координата в мм
    public double Y;       // координата в мм
    public double Z;       // координата в мм
    public string Name;   // для представления
    public bool AllowDelta; // необходимость учитывать данную точку

    public primitivGroup(double _x, double _y, double _z, string _name = "Группа", bool _allowPoint = false)
    {
        X = _x;
        Y = _y;
        Z = _z;
        Name = _name;
        AllowDelta = _allowPoint;
    }
}

[Serializable]
public class primitivCycle
{
    public double cStart;       // начальное значение цикла
    public double cStop;       // конечное значение цикла
    public double cStep;       // шаг
    public string Name;   // для представления
    public bool AllowDeltaX; // необходимость применять цикл к оси X
    public bool AllowDeltaY; // необходимость применять цикл к оси Y
    public bool AllowDeltaZ; // необходимость применять цикл к оси Z

    public primitivCycle(double _cStart, double _cStop, double _cStep, bool _AllowDeltaX, bool _AllowDeltaY, bool _AllowDeltaZ, string _name = "Цикл")
    {
        cStart = _cStart;
        cStop = _cStop;
        cStep = _cStep;
        Name = _name;
        AllowDeltaX = _AllowDeltaX;
        AllowDeltaY = _AllowDeltaY;
        AllowDeltaZ = _AllowDeltaZ;
    }
}

/// <summary>
/// Примитив точка
/// </summary>
[Serializable]
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

[Serializable]
public enum primitivType
{
    catalog,
    point,
    cycler

}


/// <summary>
/// Класс для хранения данных, конструктора
/// </summary>
[Serializable]
public class primitivNode
{
    public string GUID;
    public primitivType typeNode;
    public primitivGroup catalog;
    public primitivCycle cycler;
    public primitivPoint point;
    public List<primitivNode> nodes;

    public primitivNode()
    {
        GUID = "";
        typeNode = primitivType.catalog;
        catalog = null;
        point = null;
        nodes = new List<primitivNode>();
    }


    public primitivNode(primitivGroup _catalog)
    {
        GUID = Guid.NewGuid().ToString();
        typeNode = primitivType.catalog;
        catalog = _catalog;
        point = null;
        //line = null;
        nodes = new List<primitivNode>();
    }

    public primitivNode(primitivCycle _cycle)
    {
        GUID = Guid.NewGuid().ToString();
        typeNode = primitivType.cycler;
        cycler = _cycle;
        point = null;
        catalog = null;
        nodes = new List<primitivNode>();
    }

    public primitivNode(primitivPoint _point)
    {
        GUID = Guid.NewGuid().ToString();
        typeNode = primitivType.point;
        catalog = null;
        point = _point;
        //line = null;
        nodes = new List<primitivNode>();
    }

    public primitivNode(string _GUID, primitivType _typeNode, primitivGroup _catalog, primitivPoint _point, List<primitivNode> _nodes)
    {
        GUID = _GUID;
        typeNode = _typeNode;
        catalog = _catalog;
        point = _point;
        nodes = _nodes;
    }
}


//////// Добавление новой линии в дерево
//////public void AddNewLine()
//////{
//////    TreeNode pNode = treeDataConstructor.SelectedNode;

//////    // попытаемся получить вышестоящий узел в дереве
//////    if (pNode == null) pNode = treeDataConstructor.Nodes[0];

//////    if (pNode == null) // всетаки неудалось.......
//////    {
//////        MessageBox.Show(@"DANGER!!! Ошибка указания родителя?!?!");
//////        return;
//////    }


//////    // найдем вышестоящий узел в ListPrimitives
//////    primitivNode pnfind = findNodeWithGUID(pNode.Name);

//////    if (pnfind == null)
//////    {
//////        MessageBox.Show(@"DANGER!!! Ошибка поиска родителя?!?!");
//////        return;
//////    }

//////    // Сразу проверим узел выше, т.к. линию можно создавать в корне дерева, или внутри другого каталога, а создание линии внутри других элементов нелогично
//////    if (pnfind.typeNode != primitivType.catalog)
//////    {
//////        MessageBox.Show(@"Создание линии возможно только в корне, или внутри другого каталога!");
//////        return;
//////    }

//////    //TODO: !!!????

//////    ////////////////точки у линии
//////    //////////////primitivPoint pp1 = new primitivPoint(0, 0, 0);
//////    //////////////primitivPoint pp2 = new primitivPoint(1, 1, 1);

//////    //////////////primitivLine pline = new primitivLine(pp1, pp2);

//////    //////////////primitivNode pn = new primitivNode(pline);

//////    ////////////////pn.nodes.Add(new primitivNode(new primitivPoint(0,0,0)));

//////    //////////////pnfind.nodes.Add(pn);

//////    //////////////pNode.Nodes.Add(pn.GUID, "line", 3).Expand();

//////    //////////////treeDataConstructor.ExpandAll();



//////    //TreeNode tr = resultNode.Add(pn.GUID, "Line", 3);
//////    //AddNewPoint(tr);
//////    //AddNewPoint(tr);


//////    //if (_treeNode == null)
//////    //{
//////    //    TreeNode tr = treeDataConstructor.Nodes.Add("Line", "Line", 3);
//////    //    AddNewPoint(tr);
//////    //    AddNewPoint(tr);
//////    //}
//////    //else
//////    //{

//////    //    TreeNode tr = _treeNode.Nodes.Add("Line", "Line", 3);
//////    //    // т.к. линия это набор из точек
//////    //    AddNewPoint(tr);
//////    //    AddNewPoint(tr);
//////    //}


//////}




//    // 1. прямолинейное движение к начальной точке
//    code += "G0 X" + numPosX.Value.ToString() + " Y" + numPosY.Value.ToString() + "\n";
//    code += "G1 Z" + numPosZ.Value.ToString() + "\n";

//    // 2. движение змейкой


//    bool toLeft = true; // направление движения змейки


//    int countTask = (int)numericUpDown1.Value + 1;

//    decimal posZ = numPosZ.Value;

//    while (countTask > 0)
//    {


//        decimal posYNow = numPosY.Value;
//        decimal posYMax = numPosY.Value + numericUpDownSizeY.Value;
//        decimal posXMax = numPosX.Value + numericUpDownSizeX.Value;


//        while (posYNow != posYMax)
//        {
//            if (toLeft)
//            {
//                toLeft = false;
//                code += "G1 X" + posXMax.ToString() + "\n";
//            }
//            else
//            {
//                toLeft = true;
//                code += "G1 X" + numPosX.Value.ToString() + "\n";
//            }

//            if ((posYNow + numericUpDownDelta.Value) > (numPosY.Value + numericUpDownSizeY.Value))
//            {
//                posYNow = posYMax;
//            }
//            else
//            {
//                posYNow += numericUpDownDelta.Value;
//            }

//            code += "G1 Y" + posYNow.ToString() + "\n";
//        }


//        if (toLeft)
//        {
//            code += "G1 X" + posXMax.ToString() + "\n";
//        }
//        else
//        {
//            code += "G1 X" + numPosX.Value.ToString() + "\n";
//        }

//        posZ -= numericUpDown2.Value;

//        code += "G0 Z" + posZ + "\n";



//        countTask--;
//    }




//    //for (decimal y = numPosY.Value; y < (numPosY.Value + numericUpDownSizeY.Value); y += numericUpDownDelta.Value)
//    //{

//    //    

//    //    //





//    //}




//    if (radioButton2.Checked)
//    {
//        // 3. Поднятие вверх
//        code += "G0 Z" + numericUpDown3.Value.ToString() + "\n";
//    }




