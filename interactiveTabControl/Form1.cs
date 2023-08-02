namespace interactiveTabControl
{
    public partial class Form1 : Form
    {
        static public dynamic panelBtn;
        public Form1()
        {
            InitializeComponent();
            tabControl1.MouseClick += tabControl1_MouseClick;
        }

        public void agregarTab(int nombre, TabPage nb)
        {

            //limpiarPanel();

            // SE AGREGA UN PANEL EXTERNO
            if (nb.Controls.Count > 0)
                nb.Controls.RemoveAt(0);
            dynamic form;
            //dynamic panelBtn;
            //hijo1.dameNomina += sumar;

            switch (nombre)
            {
                //bool up = true;
                case 0: //PERIODOS
                    form = Application.OpenForms.OfType<panel1>().FirstOrDefault();
                    panelBtn = form ?? new panel1();
                    panelBtn.Dock = DockStyle.Fill;
                    break;
                case 1: //PERIODOS
                    form = Application.OpenForms.OfType<panel2>().FirstOrDefault();
                    panelBtn = form ?? new panel2();
                    panelBtn.Dock = DockStyle.Fill;
                    break;
                case 2: //PERIODOS
                    form = Application.OpenForms.OfType<panel3>().FirstOrDefault();
                    panelBtn = form ?? new panel3();
                    panelBtn.Dock = DockStyle.Fill;
                    break;
                    /*default: //ALGUNA OTRA OPCIÓN NO EN LA LISTA
                        form = Application.OpenForms.OfType<#Name>().FirstOrDefault();
                        panelBtn = form ?? new #Name();
                        panelBtn.Dock = DockStyle.Fill;
                        break;*/
            }

            nb.Controls.Add(panelBtn);
            nb.Tag = panelBtn;

        }

        private void CerrarPestana(int index)
        {
            if (index >= 0 && index < tabControl1.TabCount)
            {
                tabControl1.TabPages.RemoveAt(index);
            }
        }

        private void panelIntab(String tabPxge, String tabName, int panelNom)
        {
            // Verificar si ya existe un TabPage con el nombre deseado
            TabPage tabPage = FindTabPageByName(tabName);

            if (tabPage != null)
            {
                // Si el TabPage ya existe, se posiciona en el mismo.
                tabControl1.SelectedTab = tabPage;
            }
            else
            {
                // Si el TabPage no existe, lo creamos y lo agregamos al TabControl

                //Texto de la pestaña del Tab.
                tabPage = new TabPage(tabPxge);
                tabPage.Name = tabName; // Asigna el nombre deseado al Tab.



                // Agregamos el TabPage al TabControl
                tabControl1.TabPages.Add(tabPage);
                agregarTab(panelNom, tabPage);
                // Seleccionamos el nuevo TabPage
                
            }
        }

        private TabPage FindTabPageByName(string name)
        {
            foreach (TabPage tabPage in tabControl1.TabPages)
            {
                if (tabPage.Name == name)
                {
                    return tabPage;
                }
            }
            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //La función recibe, respectivamente.
            //Texto que se muestra en la pestaña del tab.
            //El nombre del Tabpage.
            //Indice del panel que va a mostrar.
            panelIntab("Panel_1", "panel1", 0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //La función recibe, respectivamente.
            //Texto que se muestra en la pestaña del tab.
            //El nombre del Tabpage.
            //Indice del panel que va a mostrar.
            panelIntab("Panel_2", "panel2", 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //La función recibe, respectivamente.
            //Texto que se muestra en la pestaña del tab.
            //El nombre del Tabpage.
            //Indice del panel que va a mostrar.
            panelIntab("Panel_3", "panel3", 2);
        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            // Verificar si se hizo clic derecho
            if (e.Button == MouseButtons.Right)
            {
                // Obtener la pestaña seleccionada al hacer clic derecho
                for (int i = 0; i < tabControl1.TabCount; i++)
                {
                    Rectangle tabRect = tabControl1.GetTabRect(i);
                    if (tabRect.Contains(e.Location))
                    {
                        // Mostrar un menú contextual para cerrar la pestaña
                        ContextMenuStrip menuCerrarPestana = new ContextMenuStrip();
                        ToolStripMenuItem cerrarPestanaMenuItem = new ToolStripMenuItem("Cerrar pestaña");
                        cerrarPestanaMenuItem.Click += (s, ev) => CerrarPestana(i);
                        menuCerrarPestana.Items.Add(cerrarPestanaMenuItem);
                        tabControl1.ContextMenuStrip = menuCerrarPestana;
                        break;
                    }
                }
            }
        }
    }
}