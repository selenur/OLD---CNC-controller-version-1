using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CNC_App.ConstructorGkode;
using CNC_App.primitiv;

namespace CNC_App
{
    public partial class GeneratorCode : Form
    {
        /// <summary>
        /// Ссылка на основную форму
        /// </summary>
        private readonly MainForm _mf;

        // Для упращения ввода новых данных, запоминается последняя введенная координата,
        // и при добавлении нового примитива эти координаты устанавливаются
        private double _lastX;       // координата в мм
        private double _lastY;       // координата в мм
        private double _lastZ;       // координата в мм

        /// <summary>
        /// Список примитивов
        /// </summary>
        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        private List<PrimitivNode> _listPrimitives = new List<PrimitivNode>();



        #region Элементы формы добавления данных

        private void GeneratorCode_Load(object sender, EventArgs e)
        {
            _listPrimitives.Clear();
            RefreshTree();
        }

        // ReSharper disable once InconsistentNaming
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
        private PrimitivNode FindNodeWithGuid(string guid, PrimitivNode node = null)
        {
            // ReSharper disable once SuggestVarOrType_SimpleTypes
            PrimitivNode rootNode = node ?? _listPrimitives[0];

            if (rootNode.Guid == guid) return rootNode;

            foreach (PrimitivNode variable in rootNode.Nodes)
            {
                if (variable.Guid == guid) return variable;

                //так-же запустим поиск внутри подчиненных узлов
                // ReSharper disable once SuggestVarOrType_SimpleTypes
                PrimitivNode ppn = FindNodeWithGuid(guid, variable);

                if (ppn != null) return ppn;
            }
            return null;
        }

        // Добавление новой группы в "дерево данных"
        private void AddNewGroup()
        {
            // попытаемся получить вышестоящий узел в дереве
            // ReSharper disable once SuggestVarOrType_SimpleTypes
            TreeNode pNode = treeDataConstructor.SelectedNode ?? treeDataConstructor.Nodes[0];


            if (pNode == null) // всетаки неудалось.......
            {
                MessageBox.Show(@"DANGER!!! Ошибка указания родителя?!?!");
                return;
            }

            // найдем вышестоящий узел в ListPrimitives
            PrimitivNode pnfind = FindNodeWithGuid(pNode.Name);

            if (pnfind == null)
            {
                MessageBox.Show(@"DANGER!!! Ошибка поиска родителя?!?!");
                return;
            }

            // Сразу проверим узел выше, т.к. каталог можно создавать в корне дерева, или внутри другого каталога, а создание каталога внутри других элементов нелогично
            if (!(pnfind.TypeNode == PrimitivType.Catalog || pnfind.TypeNode == PrimitivType.Cycler || pnfind.TypeNode == PrimitivType.Rotate))
            {
                MessageBox.Show(@"Создание каталога в нутри данного примитива невозможно!");
                return;
            }

            // вызовем диалог добавления группы
            frmCatalog fCatalog = new frmCatalog(_mf)
            {
                deltaX = {Value = (decimal) _lastX},
                deltaY = {Value = (decimal) _lastY},
                deltaZ = {Value = (decimal) _lastZ}
            };

            DialogResult dlResult = fCatalog.ShowDialog();

            if (dlResult == DialogResult.OK)
            {
                _lastX = (double)fCatalog.deltaX.Value;
                _lastY = (double)fCatalog.deltaY.Value;
                _lastZ = (double)fCatalog.deltaZ.Value;

                PrimitivNode pn = new PrimitivNode(new PrimitivCatalog((double)fCatalog.deltaX.Value, (double)fCatalog.deltaY.Value, (double)fCatalog.deltaZ.Value, (double)fCatalog.deltaRotate.Value, fCatalog.textBoxName.Text));
                pnfind.Nodes.Add(pn);
                RefreshTree();
            }
        }

        // Добавление новой точки в дерево
        private void AddNewPoint()
        {
            TreeNode pNode = treeDataConstructor.SelectedNode ?? treeDataConstructor.Nodes[0];

            // попытаемся получить вышестоящий узел в дереве

            if (pNode == null) // всетаки неудалось.......
            {
                MessageBox.Show(@"DANGER!!! Ошибка указания родителя?!?!");
                return;
            }

            // найдем вышестоящий узел в ListPrimitives
            PrimitivNode pnfind = FindNodeWithGuid(pNode.Name);

            if (pnfind == null)
            {
                MessageBox.Show(@"DANGER!!! Ошибка поиска родителя?!?!");
                return;
            }

            // Сразу проверим узел выше, т.к. точку внутри точки создавать нелогично
            if (pnfind.TypeNode == PrimitivType.Point)
            {
                MessageBox.Show(@"Создание точки в нутри данного примитива невозможно!");
                return;
            }

            frmPoint fPoint = new frmPoint
            {
                numPosX = {Value = (decimal) _lastX},
                numPosY = {Value = (decimal) _lastY},
                numPosZ = {Value = (decimal) _lastZ}
            };

            DialogResult dlResult = fPoint.ShowDialog();

            if (dlResult == DialogResult.OK)
            {
                _lastX = (double)fPoint.numPosX.Value;
                _lastY = (double)fPoint.numPosY.Value;
                _lastZ = (double)fPoint.numPosZ.Value;

                PrimitivNode pn = new PrimitivNode(new PrimitivPoint((double)fPoint.numPosX.Value, (double)fPoint.numPosY.Value, (double)fPoint.numPosZ.Value));
                pnfind.Nodes.Add(pn);
                RefreshTree();
            }
        }


        private void AddNewCycle()
        {
            TreeNode pNode = treeDataConstructor.SelectedNode ?? treeDataConstructor.Nodes[0];

            // попытаемся получить вышестоящий узел в дереве

            if (pNode == null) // всетаки неудалось.......
            {
                MessageBox.Show(@"DANGER!!! Ошибка указания родителя?!?!");
                return;
            }

            // найдем вышестоящий узел в ListPrimitives
            PrimitivNode pnfind = FindNodeWithGuid(pNode.Name);

            if (pnfind == null)
            {
                MessageBox.Show(@"DANGER!!! Ошибка поиска родителя?!?!");
                return;
            }

            // Сразу проверим узел выше, т.к. Циклёр можно создавать в корне дерева, или внутри другого каталога, а создание Циклёра внутри других элементов нелогично
            if (!(pnfind.TypeNode == PrimitivType.Catalog || pnfind.TypeNode == PrimitivType.Cycler || pnfind.TypeNode == PrimitivType.Rotate))
            {
                MessageBox.Show(@"Создание циклёра в нутри данного примитива невозможно!");
                return;
            }

            // вызовем диалог добавления циклёра
            frmCycler fCycler = new frmCycler(_mf);

            DialogResult dlResult = fCycler.ShowDialog();

            if (dlResult == DialogResult.OK)
            {
                PrimitivNode pn = new PrimitivNode(new PrimitivCycle((double)fCycler.numStart.Value, (double)fCycler.numStop.Value, (double)fCycler.numStep.Value, fCycler.cbX.Checked, fCycler.cbY.Checked, fCycler.cbZ.Checked, fCycler.textBoxName.Text));
                pnfind.Nodes.Add(pn);
                RefreshTree();
            }

        }


        private void AddNewRotate()
        {
            TreeNode pNode = treeDataConstructor.SelectedNode ?? treeDataConstructor.Nodes[0];

            // попытаемся получить вышестоящий узел в дереве

            if (pNode == null) // всетаки неудалось.......
            {
                MessageBox.Show(@"DANGER!!! Ошибка указания родителя?!?!");
                return;
            }

            // найдем вышестоящий узел в ListPrimitives
            PrimitivNode pnfind = FindNodeWithGuid(pNode.Name);

            if (pnfind == null)
            {
                MessageBox.Show(@"DANGER!!! Ошибка поиска родителя?!?!");
                return;
            }

            // Сразу проверим узел выше, т.к. Циклёр можно создавать в корне дерева, или внутри другого каталога, а создание Циклёра внутри других элементов нелогично
            if (!(pnfind.TypeNode == PrimitivType.Catalog || pnfind.TypeNode == PrimitivType.Cycler || pnfind.TypeNode == PrimitivType.Rotate))
            {
                MessageBox.Show(@"Создание циклёра в нутри данного примитива невозможно!");
                return;
            }

            // вызовем диалог добавления циклёра
            frmRotate frotate = new frmRotate(_mf);

            DialogResult dlResult = frotate.ShowDialog();

            if (dlResult == DialogResult.OK)
            {
                PrimitivNode pn = new PrimitivNode(new PrimitivRotate((double)frotate.centerX.Value, (double)frotate.centerY.Value, (double)frotate.centerZ.Value, (double)frotate.rotateStartAngle.Value, (double)frotate.rotateStopAngle.Value, (double)frotate.rotateStepAngle.Value, (double)frotate.rotateRadius.Value, (double)frotate.deltaStepRadius.Value, (double)frotate.RotateRotates.Value, frotate.textBoxName.Text));
                pnfind.Nodes.Add(pn);
                RefreshTree();
            }
        }

        #endregion

        // ReSharper disable once FunctionComplexityOverflow
        private void OpenFormDialog()
        {
            if (treeDataConstructor.SelectedNode == null) return;

            // Необходимость перезаполнения дерева обновленными данными
            bool needRefreshTree = false;

            //получим примитив по гуиду
            // ReSharper disable once SuggestVarOrType_SimpleTypes
            PrimitivNode pfind = FindNodeWithGuid(treeDataConstructor.SelectedNode.Name);
            //определим его тип, и откроем необходимый диалог

            if (pfind.TypeNode == PrimitivType.Catalog)
            {
                // вызовем диалог добавления группы
                // ReSharper disable once SuggestVarOrType_SimpleTypes
                frmCatalog fCatalog = new frmCatalog(_mf)
                {
                    deltaX = {Value = (decimal) pfind.Catalog.DeltaX},
                    deltaY = {Value = (decimal) pfind.Catalog.DeltaY},
                    deltaZ = {Value = (decimal) pfind.Catalog.DeltaZ},
                    textBoxName = {Text = pfind.Catalog.Name},
                    deltaRotate = {Value = (decimal) pfind.Catalog.DeltaRotate}
                };

                // ReSharper disable once SuggestVarOrType_SimpleTypes
                DialogResult dlResult = fCatalog.ShowDialog();

                if (dlResult == DialogResult.OK)
                {
                    pfind.Catalog.DeltaX = (double)fCatalog.deltaX.Value;
                    pfind.Catalog.DeltaY = (double)fCatalog.deltaY.Value;
                    pfind.Catalog.DeltaZ = (double)fCatalog.deltaZ.Value;
                    pfind.Catalog.Name = fCatalog.textBoxName.Text;
                    pfind.Catalog.DeltaRotate = (double)fCatalog.deltaRotate.Value;

                    needRefreshTree = true;
                }
            }

            if (pfind.TypeNode == PrimitivType.Cycler)
            {
                // вызовем диалог добавления группы
                // ReSharper disable once SuggestVarOrType_SimpleTypes
                frmCycler fCycler = new frmCycler(_mf)
                {
                    numStart = {Value = (decimal) pfind.Cycler.CStart},
                    numStop = {Value = (decimal) pfind.Cycler.CStop},
                    numStep = {Value = (decimal) pfind.Cycler.CStep},
                    textBoxName = {Text = pfind.Cycler.Name},
                    cbX = {Checked = pfind.Cycler.AllowDeltaX},
                    cbY = {Checked = pfind.Cycler.AllowDeltaY},
                    cbZ = {Checked = pfind.Cycler.AllowDeltaZ}
                };


                // ReSharper disable once SuggestVarOrType_SimpleTypes
                DialogResult dlResult = fCycler.ShowDialog();

                if (dlResult == DialogResult.OK)
                {
                    pfind.Cycler.CStart = (double)fCycler.numStart.Value;
                    pfind.Cycler.CStop = (double)fCycler.numStop.Value;
                    pfind.Cycler.CStep = (double)fCycler.numStep.Value;

                    pfind.Cycler.Name = fCycler.textBoxName.Text;
                    pfind.Cycler.AllowDeltaX = fCycler.cbX.Checked;
                    pfind.Cycler.AllowDeltaY = fCycler.cbY.Checked;
                    pfind.Cycler.AllowDeltaZ = fCycler.cbZ.Checked;

                    needRefreshTree = true;
                }
            }


            if (pfind.TypeNode == PrimitivType.Rotate)
            {
                // вызовем диалог добавления группы
                // ReSharper disable once SuggestVarOrType_SimpleTypes
                frmRotate frotate = new frmRotate(_mf)
                {
                    centerX = {Value = (decimal) pfind.Rotate.X},
                    centerY = {Value = (decimal) pfind.Rotate.Y},
                    centerZ = {Value = (decimal) pfind.Rotate.Z},
                    rotateRadius = {Value = (decimal) pfind.Rotate.Radius},
                    rotateStartAngle = {Value = (decimal) pfind.Rotate.AngleStart},
                    rotateStopAngle = {Value = (decimal) pfind.Rotate.AngleStop},
                    rotateStepAngle = {Value = (decimal) pfind.Rotate.AngleStep},
                    deltaStepRadius = {Value = (decimal) pfind.Rotate.DeltaStepRadius},
                    RotateRotates = {Value = (decimal) pfind.Rotate.RotateRotates},
                    textBoxName = {Text = pfind.Rotate.Name}
                };







                DialogResult dlResult = frotate.ShowDialog();

                if (dlResult == DialogResult.OK)
                {
                    pfind.Rotate.Name = frotate.textBoxName.Text;

                    pfind.Rotate.X = (double)frotate.centerX.Value;
                    pfind.Rotate.Y=(double)frotate.centerY.Value;
                    pfind.Rotate.Z=(double)frotate.centerZ.Value;

                    pfind.Rotate.Radius=(double)frotate.rotateRadius.Value;
                    pfind.Rotate.AngleStart=(double)frotate.rotateStartAngle.Value;
                    pfind.Rotate.AngleStop=(double)frotate.rotateStopAngle.Value;
                    pfind.Rotate.AngleStep=(double)frotate.rotateStepAngle.Value;

                    pfind.Rotate.DeltaStepRadius = (double)frotate.deltaStepRadius.Value;
                    pfind.Rotate.RotateRotates = (double)frotate.RotateRotates.Value;

                    needRefreshTree = true;
                }
            }



            if (pfind.TypeNode == PrimitivType.Point)
            {
                // вызовем диалог добавления группы
                frmPoint fPoint = new frmPoint
                {
                    numPosX = {Value = (decimal) pfind.Point.X},
                    numPosY = {Value = (decimal) pfind.Point.Y},
                    numPosZ = {Value = (decimal) pfind.Point.Z}
                };

                DialogResult dlResult = fPoint.ShowDialog();

                if (dlResult == DialogResult.OK)
                {
                    pfind.Point.X = (double)fPoint.numPosX.Value;
                    pfind.Point.Y = (double)fPoint.numPosY.Value;
                    pfind.Point.Z = (double)fPoint.numPosZ.Value;
                    needRefreshTree = true;
                }
            }

            if (needRefreshTree) RefreshTree();
        }


        // Открытие диалогов у существующих примитивов
        private void treeDataConstructor_DoubleClick(object sender, EventArgs e)
        {
            OpenFormDialog();
        }

        // рекурсивная функция для перерисовки дерева
        private void DrawPrimitivInTree(PrimitivNode primitivNode, TreeNode rootNode = null)
        {
            var trNode = rootNode == null ? treeDataConstructor.Nodes.Add("") : rootNode.Nodes.Add("");

            if (primitivNode.TypeNode == PrimitivType.Catalog)
            {
                trNode.ImageIndex = 1;
                trNode.Name = primitivNode.Guid;
                trNode.Text = primitivNode.Catalog.Name;
            }

            if (primitivNode.TypeNode == PrimitivType.Cycler)
            {
                trNode.ImageIndex = 4;
                trNode.Name = primitivNode.Guid;

                trNode.Text = primitivNode.Cycler.Name + @"(с: " + primitivNode.Cycler.CStart + @" по: " + primitivNode.Cycler.CStop + @" шаг:" + +primitivNode.Cycler.CStep + @")";
            }

            if (primitivNode.TypeNode == PrimitivType.Rotate)
            {
                trNode.ImageIndex = 6;
                trNode.Name = primitivNode.Guid;

                trNode.Text = primitivNode.Rotate.Name;// + "(с: " + _primitivNode.cycler.cStart + " по: " + _primitivNode.cycler.cStop + " шаг:" + +_primitivNode.cycler.cStep + ")";
            }



            if (primitivNode.TypeNode == PrimitivType.Point)
            {
                trNode.ImageIndex = 2;
                trNode.Name = primitivNode.Guid;
                trNode.Text = @"Точка: (" + primitivNode.Point.X + @", " + primitivNode.Point.Y + @", "  + primitivNode.Point.Z + @")";
            }

            if (primitivNode.Nodes.Count == 0) return;

            foreach (PrimitivNode variable in primitivNode.Nodes)
                DrawPrimitivInTree(variable, trNode);
        }
        
        // перерисовка данных
        private void RefreshTree()
        {
            //элемент на котом нужно будет спозиционироваться
            string guiDselectedNode = "";

            if (treeDataConstructor.SelectedNode != null) guiDselectedNode = treeDataConstructor.SelectedNode.Name;

            treeDataConstructor.Nodes.Clear();

            //Если нет данных
            if (_listPrimitives.Count == 0)
            {
                PrimitivNode pp = new PrimitivNode(new PrimitivCatalog(0, 0, 0, 0, "Точка старта"));
                _listPrimitives.Add(pp);
                guiDselectedNode = pp.Guid;
            }

            treeDataConstructor.BeginUpdate();
            treeDataConstructor.Nodes.Clear();

            DrawPrimitivInTree(_listPrimitives[0]);

            treeDataConstructor.EndUpdate();
            treeDataConstructor.ExpandAll();

            // и G-код сразу сгенерируем
            CREATE_GKOD();


            // установим активность на узле с GUIDselectedNode
            TreeNode[] trArray = treeDataConstructor.Nodes.Find(guiDselectedNode, true);

            if (trArray.Length != 0) treeDataConstructor.SelectedNode = trArray[0];


        }


        // Получение G-кода из данных конструктора
        private void ParsePrimitivesToGkode(ref string strCode, PrimitivNode node, double deltaX = 0, double deltaY = 0, double deltaZ = 0, double deltaRotate = 0)
        {
            if (node.TypeNode == PrimitivType.Point)
            {
                double rotatedX = node.Point.X * Math.Cos(deltaRotate * (Math.PI / 180)) - node.Point.Y * Math.Sin(deltaRotate * (Math.PI / 180));
                double rotatedY = node.Point.X * Math.Sin(deltaRotate * (Math.PI / 180)) + node.Point.Y * Math.Cos(deltaRotate * (Math.PI / 180));

                double xpp = rotatedX + deltaX;
                double ypp = rotatedY + deltaY;
                double zpp = node.Point.Z + deltaZ;

                strCode += "G1 X" + (Math.Round(xpp,3)) + " Y" + (Math.Round(ypp,3)) + " Z" + (zpp) + "\n";
                return;
            }


            if (node.TypeNode == PrimitivType.Catalog)
            {
                double dX = deltaX;       // координата в мм
                double dY = deltaY;       // координата в мм
                double dZ = deltaZ;       // координата в мм
                double dR = deltaRotate;  // значение в градусах

                dX += node.Catalog.DeltaX;
                dY += node.Catalog.DeltaY;
                dZ += node.Catalog.DeltaZ;
                dR += node.Catalog.DeltaRotate;

                foreach (PrimitivNode variable in node.Nodes)
                {
                    ParsePrimitivesToGkode(ref strCode,variable,dX,dY,dZ,dR);
                }
            }



            if (node.TypeNode == PrimitivType.Cycler)
            {
                if (node.Cycler.CStart < node.Cycler.CStop)
                {
                    for (double i = node.Cycler.CStart; i < node.Cycler.CStop; i += node.Cycler.CStep)
                    {
                    
                        double dX = deltaX;       // координата в мм
                        double dY = deltaY;       // координата в мм
                        double dZ = deltaZ;       // координата в мм

                        if (node.Cycler.AllowDeltaX) dX += i;

                        if (node.Cycler.AllowDeltaY) dY += i;

                        if (node.Cycler.AllowDeltaZ) dZ += i;
                    
                        foreach (PrimitivNode variable in node.Nodes)
                        {
                            ParsePrimitivesToGkode(ref strCode, variable, dX, dY, dZ);
                        }
                    }    
                }
                else
                {
                    for (double i = node.Cycler.CStart; i > node.Cycler.CStop; i -= node.Cycler.CStep)
                    {

                        double dX = deltaX;       // координата в мм
                        double dY = deltaY;       // координата в мм
                        double dZ = deltaZ;       // координата в мм

                        if (node.Cycler.AllowDeltaX) dX += i;

                        if (node.Cycler.AllowDeltaY) dY += i;

                        if (node.Cycler.AllowDeltaZ) dZ += i;

                        foreach (PrimitivNode variable in node.Nodes)
                        {
                            ParsePrimitivesToGkode(ref strCode, variable, dX, dY, dZ);
                        }
                    }
                }
            }  
            
            if (node.TypeNode == PrimitivType.Rotate)
                {
                    double dZ = deltaZ;  // координата в мм

                    double dSr = node.Rotate.DeltaStepRadius; // дельта изменения радиуса с каждым шагом
                    double dRo = node.Rotate.RotateRotates;   // угол дополнительного вращения объекта
                    double nowdRo = 0;

                    double dRadius = node.Rotate.Radius;

                    for (double angle = node.Rotate.AngleStart; angle < node.Rotate.AngleStop; angle += node.Rotate.AngleStep)
                    {
                        double x1 = node.Rotate.X + dRadius * Math.Cos(angle * (Math.PI / 180));
                        double y1 = node.Rotate.Y + dRadius * Math.Sin(angle * (Math.PI / 180));


                        var dX = x1+deltaX;       // координата в мм
                        var dY = y1+deltaY;       // координата в мм
                        //dZ += _node.catalog.Z;

                        foreach (PrimitivNode variable in node.Nodes)
                        {
                            ParsePrimitivesToGkode(ref strCode, variable, dX, dY, dZ, nowdRo);
                            nowdRo += dRo;

                        }

                        dRadius += dSr;

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

        private void DeleteNode(string guid, PrimitivNode primitiv)
        {
            foreach (PrimitivNode variable in primitiv.Nodes)
            {
                if (variable.Guid == guid)
                {
                    primitiv.Nodes.Remove(variable);
                    break; //дальше продолжать нельзя, т.к. сломали выборку
                }
                else DeleteNode(guid, variable);
            }
        }



        ///////// <summary>
        ///////// Функция заменяет все гуиды на новые.
        ///////// </summary>
        ///////// <param name="_primitives"></param>
        ///////// <returns></returns>
        //////private PrimitivNode SetNewGUID(PrimitivNode _primitives)
        //////{
        //////    PrimitivNode returnValue = _primitives;

        //////    returnValue.Guid = System.Guid.NewGuid().ToString();

        //////    foreach (PrimitivNode variable in returnValue.Nodes)
        //////    {
        //////        variable = SetNewGUID(variable);
        //////    }



        //////    return returnValue;
        //////}


        private void openDialogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormDialog();
        }

        private void btSaveToFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = @"Данные конструктора (*.dat)|*.dat|Все файлы (*.*)|*.*"
            };

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
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog
                {
                    Filter = @"Данные конструктора (*.dat)|*.dat|Все файлы (*.*)|*.*"
                };

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    BinaryFormatter binFormat = new BinaryFormatter();

                    using (Stream fStream = File.OpenRead(openFileDialog1.FileName))
                    {
                        PrimitivNode pNode = (PrimitivNode)binFormat.Deserialize(fStream);
                        _listPrimitives[0] = pNode;
                    }
                    RefreshTree();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка парсинга файла с данными! " + ex.Message);

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

        /// <summary>
        /// Буфер для хранения промежуточных данных
        /// </summary>
        private PrimitivNode _clipboardPrimitivNode;

        // контекст меню копировать
        private void ToolStripMenuCopyDATA_Click(object sender, EventArgs e)
        {
            if (treeDataConstructor.SelectedNode == null) return;

            _clipboardPrimitivNode = FindNodeWithGuid(treeDataConstructor.SelectedNode.Name);
        }
        // контекст меню вставить
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeDataConstructor.SelectedNode == null) return;

            PrimitivNode tmp = FindNodeWithGuid(treeDataConstructor.SelectedNode.Name);

            // надо перед вставкой все гуиды поменять на новые
            _clipboardPrimitivNode.SetNewGUID();

            // а теперь вставляем
            tmp.Nodes.Add(_clipboardPrimitivNode);

            _clipboardPrimitivNode = null;

            RefreshTree();
        }
        // контекст меню вырезать
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeDataConstructor.SelectedNode == null) return;

            _clipboardPrimitivNode = FindNodeWithGuid(treeDataConstructor.SelectedNode.Name);

            DeleteNode(treeDataConstructor.SelectedNode.Name, _listPrimitives[0]);

            RefreshTree();
        }
        // контекст меню удалить
        private void delPrimitivToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeDataConstructor.SelectedNode == null) return;

            if (MessageBox.Show("Удалить выделенный примитив?", "Удаление", MessageBoxButtons.OKCancel) != DialogResult.OK) return;

            DeleteNode(treeDataConstructor.SelectedNode.Name, _listPrimitives[0]);

            RefreshTree();
        }

        private void contextMenu_Opening(object sender, CancelEventArgs e)
        {
            pasteToolStripMenuItem.Enabled = (_clipboardPrimitivNode != null);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            AddNewRotate();
        }

        private void SaveToFile_Click(object sender, EventArgs e)
        {
            if (_listPrimitives.Count == 0) return;

            SaveFileDialog saveFileDialog = new SaveFileDialog {Filter = @"G-код (*.txt)|*.txt|Все файлы (*.*)|*.*"};

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string code = "";
                ParsePrimitivesToGkode(ref code, _listPrimitives[0]);

                StreamWriter sw = new StreamWriter(new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write));
                sw.Write(code);
                sw.Close();
            }
        }
    }
}

/// <summary>
/// Типы примитивов
/// </summary>
[Serializable]
public enum PrimitivType
{
    Catalog,
    Point,
    Cycler,
    Rotate
}

/// <summary>
/// Класс описания группы элементов
/// </summary>
[Serializable]
public class PrimitivCatalog
{
    //Смещения елементов в нутри данной группы
    public double DeltaX;       // координата в мм
    public double DeltaY;       // координата в мм
    public double DeltaZ;       // координата в мм

    //угол поворота
    public double DeltaRotate;       // координата в мм
    
    // для представления
    public string Name;

    public PrimitivCatalog(double deltaX, double deltaY, double deltaZ, double deltaRotate, string name = "Группа")
    {
        DeltaX = deltaX;
        DeltaY = deltaY;
        DeltaZ = deltaZ;
        DeltaRotate = deltaRotate;
        Name = name;
    }
}

/// <summary>
/// Класс описания вращения (пока на плоскости xy)
/// </summary>
[Serializable]
public class PrimitivRotate
{
    //центр вращения
    public double X;  // координата в мм
    public double Y;  // координата в мм
    public double Z;  // координата в мм
    // шаг вращения
    public double AngleStart;  // градус начала
    public double AngleStop;   // градус окончания
    public double AngleStep;   // градус шага
    public double Radius;      // радиус окружности

    public double DeltaStepRadius; // изменение радиуса с каждым шагом
    public double RotateRotates; //градус на который вращать данные

    public string Name;   // для представления

    public PrimitivRotate(double x, double y, double z, double angleStart, double angleStop, double angleStep, double radius, double deltaStepRadius, double rotateRotates, string name = "Вращение")
    {
        X = x;
        Y = y;
        Z = z;

        AngleStart = angleStart;
        AngleStop = angleStop;
        AngleStep = angleStep;
        Radius = radius;
        DeltaStepRadius = deltaStepRadius;
        RotateRotates = rotateRotates;

        Name = name;
    }
}

/// <summary>
/// Класс описания цикла
/// </summary>
[Serializable]
public class PrimitivCycle
{
    public double CStart;       // начальное значение цикла
    public double CStop;       // конечное значение цикла
    public double CStep;       // шаг
    public string Name;   // для представления
    public bool AllowDeltaX; // необходимость применять цикл к оси X
    public bool AllowDeltaY; // необходимость применять цикл к оси Y
    public bool AllowDeltaZ; // необходимость применять цикл к оси Z

    public PrimitivCycle(double cStart, double cStop, double cStep, bool allowDeltaX, bool allowDeltaY, bool allowDeltaZ, string name = "Цикл")
    {
        CStart = cStart;
        CStop = cStop;
        CStep = cStep;
        Name = name;
        AllowDeltaX = allowDeltaX;
        AllowDeltaY = allowDeltaY;
        AllowDeltaZ = allowDeltaZ;
    }
}

/// <summary>
/// Примитив точка
/// </summary>
[Serializable]
public class PrimitivPoint
{
    public double X;       // координата в мм
    public double Y;       // координата в мм
    public double Z;       // координата в мм

    public PrimitivPoint(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }
}

/// <summary>
/// Класс для хранения данных, конструктора
/// </summary>
[Serializable]
public class PrimitivNode
{
    public string Guid;
    public PrimitivType TypeNode;

    public PrimitivCatalog Catalog;
    public PrimitivPoint Point;
    public PrimitivCycle Cycler;
    public PrimitivRotate Rotate;

    public List<PrimitivNode> Nodes;

    private PrimitivNode()
    {
        Guid = "";
        TypeNode = PrimitivType.Catalog;

        Catalog = null;
        Point = null;
        Cycler = null;
        Rotate = null;

        Nodes = new List<PrimitivNode>();
    }

    // ReSharper disable once InconsistentNaming
    public PrimitivNode(PrimitivCatalog _catalog)
    {
        Guid = System.Guid.NewGuid().ToString();
        TypeNode = PrimitivType.Catalog;

        Catalog = _catalog;
        Point = null;
        Cycler = null;
        Rotate = null;

        Nodes = new List<PrimitivNode>();
    }

    public PrimitivNode(PrimitivCycle cycle)
    {
        Guid = System.Guid.NewGuid().ToString();
        TypeNode = PrimitivType.Cycler;

        Catalog = null;    
        Point = null;   
        Cycler = cycle;
        Rotate = null;

        Nodes = new List<PrimitivNode>();
    }

    // ReSharper disable once InconsistentNaming
    public PrimitivNode(PrimitivPoint _point)
    {
        Guid = System.Guid.NewGuid().ToString();
        TypeNode = PrimitivType.Point;

        Catalog = null;
        Point = _point;
        Cycler = null;
        Rotate = null;

        Nodes = new List<PrimitivNode>();
    }

    // ReSharper disable once InconsistentNaming
    public PrimitivNode(PrimitivRotate _rotate)
    {
        Guid = System.Guid.NewGuid().ToString();
        TypeNode = PrimitivType.Rotate;

        Catalog = null;
        Point = null;
        Cycler = null;
        Rotate = _rotate;

        Nodes = new List<PrimitivNode>();
    }


    public void SetNewGUID()
    {
        Guid = System.Guid.NewGuid().ToString();
        foreach (PrimitivNode _nodes in Nodes)
        {
            _nodes.SetNewGUID();
        }
    }

}