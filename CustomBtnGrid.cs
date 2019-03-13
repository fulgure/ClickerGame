using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace clickerGame
{
    public partial class btnGrid : UserControl
    {
        private int _selectedIndex;
        private Color _toggledColor = Color.Turquoise;
        private Color _untoggledColor = Color.Black;
        private int _numberOfButtons = 1;
        private Color _toggledForeColor = Color.Black;
        private Color _untoggledForeColor = Color.Turquoise;
        private Font _childFont = Button.DefaultFont;
        private List<Button> _childs = new List<Button>();
        private Size _childSize;
        private string _textValue = "1,10,25,100,MAX";
        private int _borderSize = 3;
        private Color _borderColor = Color.Turquoise;

        /// <summary>
        /// La taille de chaque bouton
        /// </summary>
        private Size ChildSize
        {
            get
            {
                return _childSize;
            }
            set
            {
                _childSize = value;
            }
        }

        /// <summary>
        /// La taille du composant
        /// (Mot clé new pour remplacer la propriété Size par défaut, pour pouvoir update l'affichage
        ///  lorsque le composant est resize)
        /// </summary>
        public new Size Size
        {
            get => base.Size;
            set
            {
                base.Size = value;
                UpdateGraphicComponents();
            }
        }
        /// <summary>
        /// Le texte (CSV) représantant les valeurs voulues
        /// (1,10,100 créera 3 boutons avec les valeurs 1, 10 et 100)
        /// </summary>
        [Browsable(true)]
        public override string Text
        {
            get
            {
                return TextValue;
            }
            set
            {
                TextValue = value;
                UpdateFromCSV();
            }
        }
        /// <summary>
        /// Le nombre de boutons
        /// </summary>
        [Browsable(true)]
        public int NumberOfButtons
        {
            get => _numberOfButtons;
            set
            {
                if (value <= 0)
                    value = 1;
                _numberOfButtons = value;
                UpdateGraphicComponents();
            }
        }

        [Browsable(true)]
        public string SelectedValue
        {
            get { return Childs[SelectedIndex].Text; }
            set { Childs[SelectedIndex].Text = value; }
        }
        /// <summary>
        /// Les boutons
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Button> Childs { get => _childs; set => _childs = value; }
        /// <summary>
        /// L'index du bouton séléctionné
        /// </summary>
        [Browsable(true)]
        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                if (value >= Childs.Count)
                    value = 0;
                _selectedIndex = value;
                UpdateChildColors();
            }
        }
        [Browsable(true)]
        public Color UntoggledColor
        {
            get => _untoggledColor;
            set
            {
                _untoggledColor = value;
                UpdateChildColors();
            }
        }
        [Browsable(true)]
        public Color ToggledColor
        {
            get => _toggledColor;
            set
            {
                _toggledColor = value;
                UpdateChildColors();
            }
        }
        [Browsable(false)]
        private string TextValue { get => _textValue; set => _textValue = value; }
        [Browsable(true)]
        public Color ToggledForeColor
        {
            get => _toggledForeColor;
            set
            {
                _toggledForeColor = value;
                UpdateChildColors();
            }

        }

        [Browsable(true)]
        public Color UntoggledForeColor
        {
            get => _untoggledForeColor;
            set
            {
                _untoggledForeColor = value;
                UpdateChildColors();
            }
        }

        public btnGrid()
        {
            InitializeComponent();
            UpdateGraphicComponents();
            this.AutoScaleMode = AutoScaleMode.None;
        }
        [Browsable(false)]
        private new Color ForeColor
        {
            get => UntoggledForeColor;
            set => UntoggledColor = value;
        }
        private Font ChildFonts
        {
            get => _childFont;
            set
            {
                _childFont = value;
                UpdateChildsFont();
            }
        }

        [Browsable(true)]
        public override Font Font
        {
            get => ChildFonts;
            set
            {
                ChildFonts = value;
            }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int BorderSize
        {
            get => _borderSize;
            set
            {
                _borderSize = value;
                UpdateChildsBorder();
            }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BorderColor
        {
            get => _borderColor;
            set
            {
                _borderColor = value;
                UpdateChildsBorder();
            }
        }

        private void UpdateChildsFont()
        {
            foreach (Button child in Childs)
            {
                child.Font = ChildFonts;
            }
        }
        private void Childs_Click(object sender, EventArgs e)
        {
            this.SelectedIndex = Convert.ToInt32((sender as Button).Tag);
        }
        private Size ComputeButtonSize()
        {
            int childWidth = Width / NumberOfButtons;
            return new Size(childWidth, Height);
        }
        public Button CreateButton()
        {
            //On set le Tag à Childs.Count pour connaître l'index du bouton
            Button template = new Button()
            {
                Parent = this,
                Tag = Childs.Count,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderColor = this.BorderColor, BorderSize = this.BorderSize },
                Margin = new Padding(0),
                BackColor = this.UntoggledColor,
                ForeColor = this.UntoggledForeColor,
                Font = this.Font
            };
            template.Click += Childs_Click;
            return template;
        }

        /// <summary>
        /// Récupère un csv et transforme la liste de boutons en conséquences
        /// (Crée/Supprime des boutons si requis)
        /// </summary>
        /// <param name="csv">Les nouvelles valeurs</param>
        private void UpdateFromCSV()
        {
            string[] values = TextValue.CSVToArray();
            this.NumberOfButtons = values.Length;
            UpdateValues(values);
        }

        private void UpdateGraphicComponents()
        {
            ChildSize = ComputeButtonSize();
            UpdateListSize();
            ResizeButtons();
            UpdateLocations();
        }

        private void UpdateListSize()
        {
            if (Childs.Count > NumberOfButtons)
            {
                for (int i = Childs.Count - 1; i >= NumberOfButtons; i--)
                {
                    Controls.Remove(Childs[i]);
                    Childs.RemoveAt(i);
                }
            }
            else if (Childs.Count < NumberOfButtons)
            {
                for (int i = 0; i < NumberOfButtons - Childs.Count; i++)
                {
                    Childs.Add(CreateButton());
                }
                UpdateFromCSV();
            }
        }

        private void ResizeButtons()
        {
            foreach (Button btn in Childs)
            {
                btn.Size = ChildSize;
            }
        }
        private void UpdateValues(string[] values)
        {
            for (int i = 0; i < NumberOfButtons; i++)
            {
                Childs[i].Text = values[i];
            }
        }
        private void UpdateLocations()
        {
            int cpt = 0;
            foreach (Button btn in Childs)
            {
                int x = ChildSize.Width * cpt;

                int y = 0;
                btn.Location = new Point(x, y);
                cpt++;
            }
        }

        private void UpdateChildsBorder()
        {
            foreach (Button childButton in Childs)
            {
                childButton.FlatAppearance.BorderColor = BorderColor;
                childButton.FlatAppearance.BorderSize = BorderSize;
            }
        }
        private void UpdateChildColors()
        {
            foreach (Button child in Childs)
            {
                child.BackColor = UntoggledColor;
                child.ForeColor = UntoggledForeColor;
            }
            Childs[SelectedIndex].BackColor = ToggledColor;
            Childs[SelectedIndex].ForeColor = ToggledForeColor;

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
    }
}
