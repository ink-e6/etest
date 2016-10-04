using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calc_ikolotov;
using TextFileHistory;
using System.Reflection;

namespace Calc
{
    public partial class formCalculator : Form
    {

        public Helper Calc { get; set; }
        public FileHelper FileHelp { get; set; }

        private string ActiveOperation { get; set; }

        public formCalculator()
        {
            InitializeComponent();
            //FileHelper historyFile = FileHelp.createFile();
            Calc = new Helper();

            //получить все методы с Calc
            var methods = Calc.GetType().GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);

            //цикл по методам
            var count = 0;
            this.panel1.SuspendLayout();
            foreach (var m in methods)
            {
                //для кажд метода _ свой rb 
                CreateRadioButton(m.Name, count++);
                //m.Name
            }
            this.panel1.ResumeLayout();
        }

        private void CreateRadioButton(string Name, int index)
        {
            var rbBtn = new RadioButton();

            this.panel1.Controls.Add(rbBtn);

            rbBtn.AutoSize = true;
            rbBtn.Location = new System.Drawing.Point(4, 28 + index * 18);
            rbBtn.Name = "rbBtn" + index.ToString();
            rbBtn.Size = new System.Drawing.Size(53, 17);
            rbBtn.TabIndex = 1;
            rbBtn.TabStop = true;
            rbBtn.Tag = Name;
            rbBtn.Text = Name;
            rbBtn.UseVisualStyleBackColor = true;
            rbBtn.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
        }


        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            var rb = sender as RadioButton;
            if (rb == null)
            {
                return;
            }

            ActiveOperation = rb.Tag.ToString();
        }

        private void btnCalc_Click_1(object sender, EventArgs e)
        {

            int x = 0;
            int y = 0;
            var calcType = Calc.GetType();
            var method = calcType.GetMethod(ActiveOperation);

            try
            {
                if(!int.TryParse(txtX.Text, out x))
                {
                    throw new FormatException();
                }

                if (!int.TryParse(txtY.Text, out y))
                {
                    throw new FormatException();
                }
                else
                {
                    if (y == 0 && method.Name == "Divide")
                    {
                        throw new DivideByZeroException();
                    }
                }

                var result = method.Invoke(Calc, new object[] { x, y });
                //Calc.Sum(x, y);

                lblResult.Text = result.ToString();

                rtbHistory.Text += string.Format("{0} {1} {2} = {3}{4}", x, ActiveOperation, y, result, Environment.NewLine);
            }

            catch (DivideByZeroException)
            {
                lblResult.Text = "Ошибка";

                rtbHistory.Text += string.Format("{0} {1} {2} = ОШИБКА: деление на 0 {3}", x, ActiveOperation, y, Environment.NewLine);
            }

            catch (FormatException)
            {
                lblResult.Text = "Ошибка";
                rtbHistory.Text += string.Format("{0} {1} {2} = ОШИБКА: Не число {3}", x, ActiveOperation, y, Environment.NewLine);
            }
        }

     }
}
