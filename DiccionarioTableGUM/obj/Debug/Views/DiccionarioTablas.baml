   M S B A M L   `   `   `  ����N  JDiccionarioTableGUM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:DiccionarioTableGUM.ViewsDiccionarioTableGUM.Views  5   	   1    +DiccionarioTableGUM.Views.DiccionarioTablas   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:DiccionarioTableGUM.Views     5   	     � Title$  DiccionarioTablas��5   	   $	��450��6#   $	��800��60   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   � $��0��6   .+�5      �� $��Validar Cambios��6   $��603,10,10,22q�6/    J� RenderTransformOrigin$ 2.782,-1.369&�6E   $��21��6j   $��Avenir Light)�6v   $��14(�6�   5      � 5   
   $��1��6   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ DgTablas��5         AutoGenerateColumns .     CanUserAddRows .  $��Avenir Light)�6]   $��14(�6w      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Nombre tabla��6)      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6?   �� 
 �� Path$
 f_nombre�6a     5      $ Descripcion��6)   	 6>   �� $
 f_descripcion�4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $ 
Activo GUM��6-   	 6A   �� $
 f_ind_proceso_gum�  5      -   5        
Cell_Notas��$ Notas��5   =      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6m   	 6L   �� $
 f_notas�6m   4  .System.Windows.Controls.DataGridTemplateColumn  5      $
 Auto 6-      CellTemplate 5      �� 5      .R�5    "   ��  ��Name$ cmdCampo��6)   -   5        $��Campos��5    ;   6L   5!      5#      5%      5&      � 5'   
   $��1��6   $��0,0,0,10q�6   $��2��6.   .+�5(      �� -   5        $ cmdAdiccionarTablas��5(      $��Adicionar Tabla��62   $��
16,337,0,0q�6L   $
��Left=�6�   $	��126��6�   $��21��6�   $	��Top=�6�   $��Avenir Light)�6�   $��14(�6�   �� 5)      $��Exportar��6   $��655,336,0,0q�6(   $
��Left=�6=   $	��126��6X   $��21��6d   $	��Top=�6p   $��Avenir Light)�6�   $��14(�6�   �� 5*      -   5        $ cmdConfirmarCambios��5*      $��Confirmar cambios��62   $��147,338,0,0q�6p   $��21��6�   $	��Top=�6�   $
��Left=�6�   $	��126��6�   $��Avenir Light)�6�   $��14(�6�   5+      5,      5.      