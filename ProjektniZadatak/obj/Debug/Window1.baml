   M S B A M L   `   `   `  ����K  GProjektniZadatak, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ProjektniZadatakProjektniZadatak  5   	       ProjektniZadatak.Window1   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:ProjektniZadatak     5   	     � Title$  
Animal App��5   	   $	��500��6   $	��800��6)    � Icon$ dog-paw.png��65    � 
ResizeMode$ NoResize=�6H    � WindowState$ 	Maximized=�6^    � WindowStyle$
 None=�6v   ��5	      �� 5
   
    �� ImageSource$ zebraColor.jpg��6    j� Stretch$ UniformToFill=�62   .��5      � $��0q�6    � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5      $��3* �6   �� 5      $��3* �6    � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��1 �6   �� 5      $��5* �6   �� 5      $��5* �6   �� 5      $��3* �6   �� 5      $��1* �6   .+�5   
   � $��2��6   $��2��6   $��2��6-    5      �� 5      $��3* �6    �� 5      $��3* �6    .+�5#      �� -   5        $��0��5#      $	��150��6"   $	��120��6.   $��Center=�6;   $��Center=�6_   $��0q�6|   	 � Cursor$
	 Hand��6�   $��Učitati��6�   $��Microsoft YaHei UI Light)�6�   $��24(�6�   $��Center=�6�   ��5$      �� 5%      
 �� Color$
 White��6&    �� Opacity$	 0.8Q�64   5'      �� 5(      -   5        $��1��5(      $	��150��6"   $	��120��6.   $��Center=�6;   $��Center=�6_   $��0q�6|   $
	 Hand��6�   $��	Sačuvati��6�   $��Microsoft YaHei UI Light)�6�   $��24(�6�   $��Center=�6�   ��5)      �� 5*      $
 White��6&   $	 0.8Q�64   5,      5.      �� 50   
   -   5        $��2��50      $��0��6!   $��50��6.   $��50��69   $��Center=�6E   $��Right=�6i   $��0,0,30,0q�6�   $��0q�6�   $
	 Hand��6�   $��X��6�   $��Trebuchet MS)�6�   $��24(�6�   ��51      �� 52      $
 White��6"   $	 0.8Q�60   54      �� 5?   
   -   5        $
��btnM��5?      $��0��6   $��3��6-   $��2��6:   $��0,0,0,3q�6N   $��0q�6_   $��Microsoft YaHei UI Light)�6s   $��28(�6�   
�������$
	 Hand��6�   ��5@      �� 5A      $
 Black��6"   $
 0.75Q�60   .��5B   !   
Mapa Sveta5D      �� 5E   
   -   5        $��btnAS��5E      $��0��6   $��2��6.   $��2��6;   $��0,0,0,3q�6O   $��0q�6`   
�������$��28(�6�   $��Microsoft YaHei UI Light)�6�   $
	 Hand��6�   ��5F      �� 5G      $
 Black��6"   $
 0.75Q�60   .��5H   !   Životinjske vrste5J      �� 5K   
   -   5        $��btnHelp��5K      $��0��6    $��4��60   $��2��6=   $��0q�6Q   $��0q�6\   
�������$��28(�6�   $��Microsoft YaHei UI Light)�6�   $
	 Hand��6�   ��5L      �� 5M      $
 Black��6"   $
 0.75Q�60   .��5N   !   	Pomoć?5P      5Q      5R      