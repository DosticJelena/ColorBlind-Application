   M S B A M L   `   `   `  ����K  GProjektniZadatak, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ProjektniZadatakProjektniZadatak  5   	       ProjektniZadatak.Map   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:ProjektniZadatak     5   	     � Title$	  Map��5   	   $	��450��6   $	��800��6"    � Icon$ dog-paw.png��6.    � 
ResizeMode$ NoResize=�6A    � WindowState$ 	Maximized=�6W    � WindowStyle$
 None=�6o   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��1* �6   6,   �� 5      $��4* �6   6,    � RowDefinitions 5   
   �� 5      $��70 �6   6*   �� 5      $��1* �6   6*   .+�5   
   � $��0��6   $��0��6   
���   � 5      �� 5      $��1* �6#   �� 5      $��3* �6#   .+�5      �� -   5        $��0��5      $��	10,10,5,5q�6%   $��10q�69   $��0q�6E    � Cursor$
 Hand��6Y   ��5      �� 5       �� ImageSource$0 */ProjektniZadatak;component/left-arrow.png��6!   	 j� Stretch$	 Uniform=�6Z   5      5      �� 5    
   -   5        $��	zivotinje��5    0   $��0��6   $��1��6#   
���   �$��Microsoft JhengHei Light)�6U   $��16(�6{   ��5!      �� 5"      
 �� Color$
 Black��6"    �� Opacity$	 0.9Q�60   ��5$      �� 5%      .R�5&      � .+�5'      �� $��50��69   $��50��6D   ��6    �� *Image+6D   �� 5(      $��  ��6$   $��25(�6.   
������� �� Padding$ 0,10,0,0q�6O   �� 5)      $��25(�69   
�������$ 0,10,0,0q�6Z   $
 Hand��6m   ��6$   �� *Ime+6m   5*      5+      5-      �� 5<   
   -   5        $��	canvasMap��5<   !   $��1��6   $��2��62    J� 	AllowDrop . ��5=      �� 5>      $ map.jpg��6   5@      5A      5B      