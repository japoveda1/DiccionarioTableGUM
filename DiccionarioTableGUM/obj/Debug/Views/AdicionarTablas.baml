   M S B A M L   `   `   `  ����N  JDiccionarioTableGUM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:DiccionarioTableGUM.ViewsDiccionarioTableGUM.Views  5   	   /    )DiccionarioTableGUM.Views.AdicionarTablas   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:DiccionarioTableGUM.Views     5   	     � Title$  Adicionar Tablas��5   	   $	��450��6"   $	��300��6/   .��5	      � $	��419��6   $��Bottom=�6   $��0,0,2,0q�63    � RowDefinitions 5
   
   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   � $��0��6   .+�5      �� -   5        $��Con relacion��5      $
��Left=�5      $��	10,10,0,0q�5      $	��Top=�5       d� 	IsChecked$
 TrueY�5      5      � 5   
   $��1��6   $
��Auto��6   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ 
DgTablasDB��5      $��10,39,10,17q�6+      AutoGenerateColumns .     Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5!         CellTemplate 5"      �� 5#      .R�5$   "   �� -   5        5$   L   5%      5'      4  .System.Windows.Controls.DataGridCheckBoxColumn  5(      1  +System.Windows.Controls.DataGridBoundColumn   Binding 6-   ��  �� Path$ f_seleccion�0  *System.Windows.Controls.DataGridTextColumn  5)      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Nombre tablas��6)   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6h      
IsReadOnly .  6@   �� $ f_nombre_tabla�6r   5+      5,      � 5.   
   $��2��6   .+�50      �� -   5         ��Name$ cmdAdiccionarTablas��50      $��Adicionar Tabla��62   $	��126��6o   $��21��6{   $��Avenir Light)�6�   $��14(�6�   52      54      55      