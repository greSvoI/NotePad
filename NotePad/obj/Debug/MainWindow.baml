   M S B A M L   `   `   `  ����E  ANotePadWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:NotePadNotePad  5   	       NotePad.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:NotePad     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � WindowStyle$
 None=�65    J� InputBindings 5	      �� 5
   
   
 �� Key$ N��60    �� 	Modifiers$
 Ctrlf�68    �� Command 6   �� *Create+68   �� 5   
   $ O��62   $
 Ctrlf�6:    6   �� *
OpenFile+6:   �� 5   
   $ S��62   $
 Ctrlf�6:    6   �� *
SaveFile+6:    � 	Resources 5       �� 
TargetType   myButton �� Property	 �� Value
 �� 
TargetType A�Name 
� Center 
� RadiusX 
� RadiusY 
� GradientOrigin � Color � Offset �� Path �� RelativeSource �� Triggers P� Property P� Value �� 
TargetName3  -System.Windows.Media.Effects.DropShadowEffect   Color   ShadowDepth   
BlurRadius��%�  &	        �� 5   
   " ��6   .�5      ��  � ��$		 Top=�62   �� 5       � ��
	 �����6+   �� 5       � ��$	 0 5 15 5q�6'   �� 5       � ��$	 15��6&   �� 5       � ��$	 15��6'   �� 5       � ��	 5      �� 5      "
 ��6&   .R�5      � .+�5      A� $ myEllips��6&   ��5   "   
� 5   &   $ 0.5,0.5&�6:   $	 0.5Q�6K   $	 0.5Q�6Y   $ 0.6,0.3&�6g   .��5   *   � $ White��67   $	 0.0Q�6E   � 5   *   $	 0.8Q�6�    67   �� $ Background.Color� �� *TemplatedParent+6�   5   '   5!      �� 5"      $��Center=�6/   $��Center=�6L   5#       5$      P� 5%       �@J�IsMouseOver . . �5&   "   �� $ myEllips��69    � ��	 5'   &   
� 5(   *   $ 0.5,0.5&�6>   $	 0.5Q�6O   $	 0.5Q�6]   $ 0.6,0.3&�6k   .��5)   .   � $ White��6;   $	 0.0Q�6I   � 5*   .   $	 0.4Q�6�    6;   �� $ Background.Color� �� *TemplatedParent+6�   5+   +   5-   #   �� 5.   "    �@J�Effect	 5/   &     50   *   $ White��6;   $ 0Q�6I   $ 20Q�6Y   52   #   53      55      57      58      59      .��5:      � .+�5;   
   ]� -   5        $��	dockPanel��5;      .+�5<      �� -   5        $	��Top=�5<       �� Orientation$ Vertical=�6.   $��Stretch=�6E   
���   �.+�5=      �� -   5         ��Name$ panelWindow��5=   >   
���   �$
��auto��60   $	��Top=�6S   $��30��6h   $��0 5 0 0q�6t   $ 
Horizontal=�6�   $��Right=�6�   .+�5>      �� -   5         ��Name$ buttonGreen��5>      
��� � �#��[  6F   6h   �� 5?      -   5        $ buttonOrange��5?      ���#FBB034#��[  6H   6j   �� 5@      -   5        $��	buttonRed��5@      
���  ��#��[  6?   6a   5A      5B      o� 5C      $	��Top=�6   $	��Top=�6)   
�������.@�5D      m� $��Файл��6   .@�5E      m� $��Создать��6    m� InputGestureText$ Ctrl+N��60    m� Command 6J   �� *Create+m� 5F      $��Открыть��6   $ Ctrl+O��60    6J   �� *
OpenFile+m� 5G      $��Сохранить��6    62   �� *
SaveFile+m� 5H      $��Сохранить как��6    66   �� *SaveAs+�� 5I      m� 5J      -   5        $��
Выход��5J      6.   5K      m� 5L      $��Правка��6   .@�5M      m� $��Отменить��6   $ ApplicationCommands.Undo��61     � ToolTip$
  Undo��6T   �� 5N      m� 5O      $��Вырезать��6   $ ApplicationCommands.Cut��61   $	  Cut��6S   m� 5P      $��Копировать��6   $ ApplicationCommands.Copy��63   $
  Copy��6V   m� 5Q      $��Вставить��6   $ ApplicationCommands.Paste��61   $  Paste��6U   m� 5R      $��Удалить��6   $  ApplicationCommands.Delete��60   $  Delete��6U   �� 5S      m� 5T      $��Выделить все��6   $# ApplicationCommands.SelectAll��65   $  	SelectAll��6]   m� 5U      $��Автозапуск��6   ! m� IsCheckable! . " m� 	IsChecked" 6F   �� *	AutoRun+5V      m� 5W      $��Формат��6   .@�5X      m� -   5        $��Цвет шрифта��5X      64   m� 5Y      -	   5        $��Размер шрифта��5Y      66   m� 5Z      $��Формат .cs��6    63   �� *
FormatCS+5[      5\      �� 5d      $��Bottom=�6   .+�5e      �� ��6   �� *
FileName+5f      5g      5i      5j      