namespace datagridview_and_database
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.db_tables_cellnames = new System.Windows.Forms.CheckedListBox();
            this.open_db_file_dialog = new System.Windows.Forms.OpenFileDialog();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.db_path_strings = new System.Windows.Forms.CheckedListBox();
            this.db_tables_names = new System.Windows.Forms.CheckedListBox();
            this.button10 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(740, 490);
            this.dataGridView1.TabIndex = 1;
            // 
            // db_tables_cellnames
            // 
            this.db_tables_cellnames.FormattingEnabled = true;
            this.db_tables_cellnames.Location = new System.Drawing.Point(948, 12);
            this.db_tables_cellnames.Name = "db_tables_cellnames";
            this.db_tables_cellnames.Size = new System.Drawing.Size(278, 109);
            this.db_tables_cellnames.TabIndex = 2;
            // 
            // open_db_file_dialog
            // 
            this.open_db_file_dialog.FileName = "open_db_file_dialog";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(766, 155);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(164, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "Загрузить дб в список";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.openfile);
            // 
            // button6
            // 
            this.button6.Enabled = false;
            this.button6.Location = new System.Drawing.Point(766, 77);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(164, 23);
            this.button6.TabIndex = 7;
            this.button6.Text = "get quantiy of rows";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Enabled = false;
            this.button7.Location = new System.Drawing.Point(767, 213);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(164, 23);
            this.button7.TabIndex = 9;
            this.button7.Text = "get column names";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.get_column_name);
            // 
            // button8
            // 
            this.button8.Enabled = false;
            this.button8.Location = new System.Drawing.Point(767, 242);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(163, 23);
            this.button8.TabIndex = 10;
            this.button8.Text = "загрузить дб в дгв";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.get_column_name_v2);
            // 
            // db_path_strings
            // 
            this.db_path_strings.FormattingEnabled = true;
            this.db_path_strings.Location = new System.Drawing.Point(948, 393);
            this.db_path_strings.Name = "db_path_strings";
            this.db_path_strings.Size = new System.Drawing.Size(278, 109);
            this.db_path_strings.TabIndex = 11;
            // 
            // db_tables_names
            // 
            this.db_tables_names.FormattingEnabled = true;
            this.db_tables_names.Location = new System.Drawing.Point(948, 184);
            this.db_tables_names.Name = "db_tables_names";
            this.db_tables_names.Size = new System.Drawing.Size(278, 109);
            this.db_tables_names.TabIndex = 13;
            // 
            // button10
            // 
            this.button10.Enabled = false;
            this.button10.Location = new System.Drawing.Point(767, 184);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(164, 23);
            this.button10.TabIndex = 14;
            this.button10.Text = "Get table names";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.tablenames_from_db);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(951, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 514);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.db_tables_names);
            this.Controls.Add(this.db_path_strings);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.db_tables_cellnames);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckedListBox db_tables_cellnames;
        private System.Windows.Forms.OpenFileDialog open_db_file_dialog;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.CheckedListBox db_path_strings;
        private System.Windows.Forms.CheckedListBox db_tables_names;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label label1;
    }
}

