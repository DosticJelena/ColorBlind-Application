   M S B A M L   `   `   `  ����K  GProjektniZadatak, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ProjektniZadatakProjektniZadatak  5   	   ,    &ProjektniZadatak.Prozori.EtiketaProzor   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:ProjektniZadatak     5   	     � Title$  Nova Etiketa��5   	   $	��500��6   $	��800��6+   
���   � � 
ResizeMode$ NoResize=�6J    � WindowStartupLocation$ CenterScreen=�6`   .��5	      � 
���   � � ColumnDefinitions 5
   
   �� 5      $��1* �6   �� 5      $��2* �6   �� 5      $��2 �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $��3* �6   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $��3* �6   �� 5      $��2* �6   .+�5   
   �� $��0��6   $��0��6!   $��4��61   ��5      �� 5       �� ImageSource$ 
zebra1.jpg��6    j� Stretch$ UniformToFill=�66    �� Opacity$
 0.35Q�6N   5      �� 5   
   $��2��6   $��1��6$   $��3��61   ���	#FFCBCBCB6U   �� 5   
   -   5        $��3��5      $��3��6!   $��10,10,20,10q�6.   
�������$��Microsoft YaHei Light)�6V   $��18(�6y   ��5      �� 5        �� Color$ White��6"   $	 0.4Q�60   .��5!   !   Create5"      �� 5#   
   $��0��6   $��0��6    
�������$��Microsoft YaHei Light)�6@   $��22(�6c   $��Center=�6q   $��Center=�6�   .��6�   Nova Etiketa6�   �� 5%   
   $��1��6   $��0��6   
�������$��Right=�6@   $��Center=�6\   $��Microsoft JhengHei Light)�6w   $��16(�6�   .��6�   Id:6�   �� 5&   
   $��2��6   $��0��6   
�������$��Right=�6@   $��Center=�6\   $��Microsoft JhengHei Light)�6w   $��16(�6�   .��6�   Boja:6�   �� 5'   
   $��3��6   $��0��6   
�������$��Right=�6@   $	��Top=�6\   $��Microsoft JhengHei Light)�6t   $��16(�6�   $��0,10,0,0q�6�   .��6�   Opis:6�   �� 5)   
   -   5        $��	idEtiketa��5)      $��1��6#   $��1��60   $��10,10,20,10q�6@   $��10,0,0,0q�6U   $��Center=�6h   (  "System.Windows.Controls.DatePicker  5*   
   $��2��6   $��1��6"   
���   �$
��Left=�6E   $��Center=�6`   $��10,0,0,0q�6{   $��Microsoft YaHei Light)�6�   $��16(�6�   $��0q�6�   6�   �� 5+   
   -   5        $��opisEtiketa��5+      $��3��6%   $��1��62   $��10,10,20,10q�6B   $��	10,10,0,0q�6W   5-      5.      