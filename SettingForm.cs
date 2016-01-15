using System;
using System.Windows.Forms;

namespace CNC_Assist.SettingApp
{
    public partial class SettingForm : Form
    {
        /// <summary>
        /// Наименование текущих настроек
        /// </summary>
        private string NameClassSetting = @"SettingAPP";
        /// <summary>
        /// Признак того что настройки были изменены
        /// </summary>
        private bool settingIsChanged = false;

        public SettingForm()
        {
            InitializeComponent();
        }

        private void SettingAPP_Load(object sender, EventArgs e)
        {
            // Заполение дерева доступными настройками
            treeView1.Nodes.Clear();

            TreeNode tr = new TreeNode("1. Настройки программы");
            tr.Name = @"SettingAPP";
            treeView1.Nodes.Add(tr);

            tr = new TreeNode("2. Настройки контроллера");
            tr.Name = @"SettingController";
            treeView1.Nodes.Add(tr);

            tr = new TreeNode("3. 3D отображение");
            tr.Name = @"SettingRender";
            treeView1.Nodes.Add(tr);

            tr = new TreeNode("4. Натройка модулей");
            tr.Name = @"SettingPanel";

            //TODO: сюда добавить суб панели
            treeView1.Nodes.Add(tr);

            ReloadSetting();
        }

        private void propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            settingIsChanged = true;
            RefreshElements();
            propertyGrid.Refresh();
        }

        private void AppyChange()
        {
            settingIsChanged = false;
            GlobalSetting.SaveToFile();
            RefreshElements();

            if (Controller.Connected)
            {
                Controller.Reconnect();
            }
        }

        private void ReloadSetting()
        {
            //клик по записи в дереве
            if (NameClassSetting == @"SettingAPP") propertyGrid.SelectedObject = GlobalSetting.AppSetting;

            if (NameClassSetting == @"SettingController") propertyGrid.SelectedObject = GlobalSetting.ControllerSetting;

            if (NameClassSetting == @"SettingRender") propertyGrid.SelectedObject = GlobalSetting.RenderSetting;

            if (NameClassSetting == @"SettingPanel") propertyGrid.SelectedObject = GlobalSetting.PanelSetting;

            RefreshElements();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            NameClassSetting = e.Node.Name;
            ReloadSetting();
        }

        private void RefreshElements()
        {
            btAppyChange.Enabled = settingIsChanged;
        }

        private void btAppyChange_Click(object sender, EventArgs e)
        {
            AppyChange();
        }

        private void WhenFormClose()
        {
            if (settingIsChanged)
            {
                string message = "Настройки были изменены, сохранить их, перед закрытием окна настроек?";
                string caption = "Вопрос пользователю";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    AppyChange();
                }
                else
                {
                    GlobalSetting.LoadSetting();
                }

                settingIsChanged = false;
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            WhenFormClose();

            this.Close();
        }

        private void SettingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            WhenFormClose();
        }
    }
}
