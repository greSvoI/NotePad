   M S B A M L   `   `   `  ���� E  ANotePadWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:NotePadNotePad      NotePad.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:NotePad       � Title$  
MainWindow��$	��450��$	��800�� � WindowStyle$ SingleBorderWindow=� J� InputBindings �� 
 �� Key$ N�� �� 	Modifiers$
 Ctrlf� �� Command �� *Create+�� $ O��$
 Ctrlf� �� *
OpenFile+�� $ S��$
 Ctrlf� �� *
SaveFile+ � 	Resources  �� 
TargetType   myButton �� Property	 �� Value
 �� 
TargetType A�Name 
� Center 
� RadiusX 
� RadiusY 
� GradientOrigin � Color � Offset �� Path �� RelativeSource �� Triggers P� Property P� Value �� 
TargetName3  -System.Windows.Media.Effects.DropShadowEffect   Color   ShadowDepth   
BlurRadius��%�  &	        �� " ��.���  � ��$		 Top=���  � ��
	 �������  � ��$	 0 5 15 5q���  � ��$	 15����  � ��$	 15����  � ��	 �� "
 ��.R�� .+�A� $ myEllips����
� $ 0.5,0.5&�$	 0.5Q�$	 0.5Q�$ 0.6,0.3&�.��� $ White��$	 0.0Q�� $	 0.8Q� �� $ Background.Color� �� *TemplatedParent+�� $��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� $ myEllips�� � ��	 
� $ 0.5,0.5&�$	 0.5Q�$	 0.5Q�$ 0.6,0.3&�.��� $ White��$	 0.0Q�� $	 0.4Q� �� $ Background.Color� �� *TemplatedParent+��  �@J�Effect	   $ White��$ 0Q�$ 20Q�.��� .+�]� -   $��	dockPanel��.+��� -   $	��Top=� �� Orientation$ Vertical=�$��Stretch=�
���   �.+��� -    ��Name$ panelWindow��
���   �$
��auto��$	��Top=�$��30��$��0 5 0 0q�$ 
Horizontal=�$��Right=�.+��� -    ��Name$ buttonGreen��
��� � �#��[  �� -   $ buttonOrange�����#FBB034#��[  �� -   $��	buttonRed��
���  ��#��[  o� $	��Top=�$	��Top=�
�������.@�m� $��Файл��.@�m� $��Создать�� m� InputGestureText$ Ctrl+N�� m� Command �� *Create+m� $��Открыть��$ Ctrl+O�� �� *
OpenFile+m� $��Сохранить�� �� *
SaveFile+m� $��Сохранить как�� �� *SaveAs+�� m� -   $��
Выход��m� $��Правка��.@�m� $��Отменить��$ ApplicationCommands.Undo��  � ToolTip$
  Undo���� m� $��Вырезать��$ ApplicationCommands.Cut��$	  Cut��m� $��Копировать��$ ApplicationCommands.Copy��$
  Copy��m� $��Вставить��$ ApplicationCommands.Paste��$  Paste��m� $��Удалить��$  ApplicationCommands.Delete��$  Delete���� m� $��Выделить все��$# ApplicationCommands.SelectAll��$  	SelectAll��m� $��Автозапуск��! m� IsCheckable! . " m� 	IsChecked" �� *	AutoRun+m� $��Формат��.@�m� -   $��Цвет шрифта��m� -	   $��Размер шрифта��m� $��Формат .cs�� �� *
FormatCS+�� $��Bottom=�.+��� ���� *
FileName+