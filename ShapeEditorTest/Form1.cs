﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ShapeEditorLibrary.Shapes;

namespace ShapeEditorTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void AddShape(Shape s)
        {
            canvas1.Shapes.Add(s);
            canvas1.Invalidate();
            
        }

        private void addRectangleButton_Click(object sender, EventArgs e)
        {
            this.AddShape(new RectangleShape(Point.Empty));
        }

        private void addEllipseButton_Click(object sender, EventArgs e)
        {
            this.AddShape(new EllipseShape(Point.Empty));
        }

        private void addTriangleButton_Click(object sender, EventArgs e)
        {
            this.AddShape(new TriangleShape(Point.Empty));
        }

        private void canvas1_ShapesCollectionChanged(object sender, EventArgs e)
        {
            shapesComboBox1.Items.Clear();
            shapesComboBox1.Items.AddRange(canvas1.Shapes.ToArray());
        }

        private void canvas1_SelectedShapeChanged(object sender, EventArgs e)
        {
            Shape s = canvas1.SelectedShape;
            shapesComboBox1.SelectedItem = s;
            propertyGrid1.SelectedObject = s;
            
        }

        private void shapesComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Shape s = shapesComboBox1.SelectedItem as Shape;
            if (s != null)
            {
                canvas1.SetSelection(s);
            }
            else
            {
                canvas1.SetSelection(null);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //this.AddShape(new Pipeline(Point.Empty));
            this.AddShape(new Pipeline(Point.Empty));
            
        }

       

        private void canvas1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shape s = canvas1.SelectedShape;
            if(s!=null)
                canvas1.RemoveShape(s);
        }

        private void наПереднийПланToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shape s = canvas1.SelectedShape;
            if (s != null)
                canvas1.BringToFront(s);
        }

        private void наЗаднийПланToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shape s = canvas1.SelectedShape;
            if (s != null)
                canvas1.SendToBack(s);
        }
    }
}