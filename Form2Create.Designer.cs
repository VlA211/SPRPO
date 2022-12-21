
namespace _2_ЛАБА_ПРОГА_БАЗА_ДАННЫХ
{
    partial class Form2Create
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button4Save = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2Count = new System.Windows.Forms.TextBox();
            this.textBox1Name = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button4Save
            // 
            this.button4Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4Save.Location = new System.Drawing.Point(12, 147);
            this.button4Save.Name = "button4Save";
            this.button4Save.Size = new System.Drawing.Size(260, 50);
            this.button4Save.TabIndex = 13;
            this.button4Save.Text = "Добавить";
            this.button4Save.UseVisualStyleBackColor = true;
            this.button4Save.Click += new System.EventHandler(this.button4Save_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(20, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Количество объектов";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(20, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Наименование объекта";
            // 
            // textBox2Count
            // 
            this.textBox2Count.Location = new System.Drawing.Point(12, 94);
            this.textBox2Count.Name = "textBox2Count";
            this.textBox2Count.Size = new System.Drawing.Size(260, 20);
            this.textBox2Count.TabIndex = 10;
            // 
            // textBox1Name
            // 
            this.textBox1Name.Location = new System.Drawing.Point(12, 37);
            this.textBox1Name.Name = "textBox1Name";
            this.textBox1Name.Size = new System.Drawing.Size(260, 20);
            this.textBox1Name.TabIndex = 9;
            // 
            // Form2Create
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 209);
            this.Controls.Add(this.button4Save);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2Count);
            this.Controls.Add(this.textBox1Name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MinimumSize = new System.Drawing.Size(300, 248);
            this.Name = "Form2Create";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Новый объект";
            this.Load += new System.EventHandler(this.Form2Create_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button4Save;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2Count;
        private System.Windows.Forms.TextBox textBox1Name;
    }
}