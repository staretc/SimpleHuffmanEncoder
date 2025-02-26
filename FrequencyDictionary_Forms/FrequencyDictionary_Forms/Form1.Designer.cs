namespace FrequencyDictionary_Forms
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonInput = new System.Windows.Forms.Button();
            this.listBoxCodes = new System.Windows.Forms.ListBox();
            this.buttonEncodeText = new System.Windows.Forms.Button();
            this.buttonDecode = new System.Windows.Forms.Button();
            this.listBoxCompession = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // buttonInput
            // 
            this.buttonInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonInput.Location = new System.Drawing.Point(12, 567);
            this.buttonInput.Name = "buttonInput";
            this.buttonInput.Size = new System.Drawing.Size(128, 69);
            this.buttonInput.TabIndex = 0;
            this.buttonInput.Text = "Input Text";
            this.buttonInput.UseVisualStyleBackColor = true;
            this.buttonInput.Click += new System.EventHandler(this.buttonInput_Click);
            // 
            // listBoxCodes
            // 
            this.listBoxCodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxCodes.FormattingEnabled = true;
            this.listBoxCodes.ItemHeight = 42;
            this.listBoxCodes.Location = new System.Drawing.Point(12, 12);
            this.listBoxCodes.Name = "listBoxCodes";
            this.listBoxCodes.Size = new System.Drawing.Size(871, 550);
            this.listBoxCodes.TabIndex = 1;
            // 
            // buttonEncodeText
            // 
            this.buttonEncodeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEncodeText.Location = new System.Drawing.Point(146, 567);
            this.buttonEncodeText.Name = "buttonEncodeText";
            this.buttonEncodeText.Size = new System.Drawing.Size(149, 69);
            this.buttonEncodeText.TabIndex = 2;
            this.buttonEncodeText.Text = "Encode Text";
            this.buttonEncodeText.UseVisualStyleBackColor = true;
            this.buttonEncodeText.Click += new System.EventHandler(this.buttonEncodeText_Click);
            // 
            // buttonDecode
            // 
            this.buttonDecode.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDecode.Location = new System.Drawing.Point(301, 567);
            this.buttonDecode.Name = "buttonDecode";
            this.buttonDecode.Size = new System.Drawing.Size(149, 69);
            this.buttonDecode.TabIndex = 3;
            this.buttonDecode.Text = "Decode Text";
            this.buttonDecode.UseVisualStyleBackColor = true;
            this.buttonDecode.Click += new System.EventHandler(this.buttonDecode_Click);
            // 
            // listBoxCompession
            // 
            this.listBoxCompession.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxCompession.FormattingEnabled = true;
            this.listBoxCompession.ItemHeight = 25;
            this.listBoxCompession.Location = new System.Drawing.Point(479, 568);
            this.listBoxCompession.Name = "listBoxCompession";
            this.listBoxCompession.Size = new System.Drawing.Size(404, 54);
            this.listBoxCompession.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 658);
            this.Controls.Add(this.listBoxCompession);
            this.Controls.Add(this.buttonDecode);
            this.Controls.Add(this.buttonEncodeText);
            this.Controls.Add(this.listBoxCodes);
            this.Controls.Add(this.buttonInput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonInput;
        private System.Windows.Forms.ListBox listBoxCodes;
        private System.Windows.Forms.Button buttonEncodeText;
        private System.Windows.Forms.Button buttonDecode;
        private System.Windows.Forms.ListBox listBoxCompession;
    }
}

