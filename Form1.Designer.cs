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
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.db_path_strings = new System.Windows.Forms.CheckedListBox();
            this.db_tables_names = new System.Windows.Forms.CheckedListBox();
            this.button10 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.add_data_to_tree = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(14, 54);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(740, 490);
            this.dataGridView1.TabIndex = 1;
            // 
            // db_tables_cellnames
            // 
            this.db_tables_cellnames.FormattingEnabled = true;
            this.db_tables_cellnames.Location = new System.Drawing.Point(928, 348);
            this.db_tables_cellnames.Name = "db_tables_cellnames";
            this.db_tables_cellnames.Size = new System.Drawing.Size(50, 34);
            this.db_tables_cellnames.TabIndex = 2;
            this.db_tables_cellnames.Visible = false;
            // 
            // open_db_file_dialog
            // 
            this.open_db_file_dialog.FileName = "open_db_file_dialog";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(758, 54);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(164, 36);
            this.button5.TabIndex = 6;
            this.button5.Text = "Загрузить дб в список";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Open_db_dialog_method);
            // 
            // button7
            // 
            this.button7.Enabled = false;
            this.button7.Location = new System.Drawing.Point(984, 308);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(164, 34);
            this.button7.TabIndex = 9;
            this.button7.Text = "get column names";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.get_column_name_ver2);
            // 
            // button8
            // 
            this.button8.Enabled = false;
            this.button8.Location = new System.Drawing.Point(985, 348);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(163, 34);
            this.button8.TabIndex = 10;
            this.button8.Text = "загрузить дб в дгв";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.push_data_to_dgv_ver3);
            // 
            // db_path_strings
            // 
            this.db_path_strings.FormattingEnabled = true;
            this.db_path_strings.Location = new System.Drawing.Point(928, 54);
            this.db_path_strings.Name = "db_path_strings";
            this.db_path_strings.Size = new System.Drawing.Size(278, 109);
            this.db_path_strings.TabIndex = 11;
            // 
            // db_tables_names
            // 
            this.db_tables_names.FormattingEnabled = true;
            this.db_tables_names.Location = new System.Drawing.Point(928, 308);
            this.db_tables_names.Name = "db_tables_names";
            this.db_tables_names.Size = new System.Drawing.Size(50, 34);
            this.db_tables_names.TabIndex = 13;
            this.db_tables_names.Visible = false;
            // 
            // button10
            // 
            this.button10.Enabled = false;
            this.button10.Location = new System.Drawing.Point(984, 272);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(164, 30);
            this.button10.TabIndex = 14;
            this.button10.Text = "Get table names";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.get_tablenames);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(928, 272);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(50, 30);
            this.listBox1.TabIndex = 16;
            this.listBox1.Visible = false;
            this.listBox1.SelectedValueChanged += new System.EventHandler(this.listBox1_SelectedValueChanged);
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(928, 169);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(278, 97);
            this.treeView1.TabIndex = 17;
            // 
            // add_data_to_tree
            // 
            this.add_data_to_tree.Location = new System.Drawing.Point(758, 96);
            this.add_data_to_tree.Name = "add_data_to_tree";
            this.add_data_to_tree.Size = new System.Drawing.Size(162, 51);
            this.add_data_to_tree.TabIndex = 18;
            this.add_data_to_tree.Text = "Добавить названия таблиц и столбцов для работы";
            this.add_data_to_tree.UseVisualStyleBackColor = true;
            this.add_data_to_tree.Click += new System.EventHandler(this.newultramethod_add_data_totree);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 551);
            this.Controls.Add(this.add_data_to_tree);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.db_tables_names);
            this.Controls.Add(this.db_path_strings);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.db_tables_cellnames);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "у";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckedListBox db_tables_cellnames;
        private System.Windows.Forms.OpenFileDialog open_db_file_dialog;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.CheckedListBox db_path_strings;
        private System.Windows.Forms.CheckedListBox db_tables_names;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button add_data_to_tree;
    }
}

