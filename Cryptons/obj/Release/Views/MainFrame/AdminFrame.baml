   M S B A M L   `   `   `  ���� C  ?Cryptons, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Cryptons.Views.MainFrameCryptons.Views.MainFrame  )    #Cryptons.Views.MainFrame.AdminFrame   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    >d2http://schemas.microsoft.com/expression/blend/2008    6local&clr-namespace:Cryptons.Views.MainFrame    b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       N� Title$  
AdminFrame��$	��640��$
��1000�� N� 
Background �#12182C.��� .+��� $	��450�����	#FF1E283E$)��#Добавление Вопроса��$��29,16,521,231q�.���� .+��� -   $��Quest�� !  MaterialDesignOutlinedTextBox#��[   �� TextWrapping$
 Wrap=�$��8q�$��Stretch=�$	��280��$��14(�)  #MaterialDesignThemes.Wpf.HintAssist   
Background �	#FF1E283E �� AcceptsReturn . 
�������" �� VerticalScrollBarVisibility$
 Auto=� �� 	IsEnabled .     Hint$! Введите вопрос��$��71��$��	0,10,0,10q��� -    ��Name$ 	ListQuest��.@��� .���� 	 �� Orientation$	 
Horizontal=�.+��� -   
 ��Name$
 Ansver1��$	��360��
�������$��14(�$ Ответ - 1��d� -    d�Name$	 Ab1�� * &MaterialDesignActionAccentToggleButton#��[  d� 	IsChecked$
 TrueY�
 � Tag$ 1�� � ToolTip$, &MaterialDesignActionAccentToggleButton��$��20,0,0,0q���0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ CloseCircleOutline=��� .���� $	 
Horizontal=�.+��� -   $
 Ansver2��$	��360��
�������$��14(�$ Ответ - 2��d� -   $	 Ab2��#��[ $ FalseY�$ 2��$, &MaterialDesignActionAccentToggleButton��$��20,0,0,0q���  $ CloseCircleOutline=��� .���� $	 
Horizontal=�.+��� -   $
 Ansver3��$	��360��
�������$��14(�$ Ответ - 3��d� -   $	 Ab3��#��[ $ FalseY�$ 3��$, &MaterialDesignActionAccentToggleButton��$��20,0,0,0q���  $ CloseCircleOutline=��� .���� $	 
Horizontal=�.+��� -	   $
 Ansver4��$	��360��
�������$��14(�$ Ответ - 4��d� -
   $	 Ab4��#��[ $ FalseY�$ 4��$, &MaterialDesignActionAccentToggleButton��$��20,0,0,0q���  $ CloseCircleOutline=��� -   $	��300��$%��Сохранить вопрос��$��10q��� $	��450�����	#FF1E283E$5��/Добавление Преподавателя��$��521,16,29,456q�.��� $	��119��$	��Top=�.+��� -   $
 UserL��$��20(�$	��200��
�������$ 
Логин��$��10,40,222,0q�$��33��$	��Top=�G� -    G�Name$ UserP��
�������$	��200��$ Пароль��$��20(�.  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton . $��222,40,10,0q�$��33��$	��Top=��� -   $
 UserN��$��20(�
�������$	��200��$ Имя��$��
10,0,222,0q�$��33��$	��Top=��� -   $
 UserF��$��20(�$	��200��
�������$ Фамилия��$��
222,0,10,0q�$��33��$	��Top=��� -   $/��)Добавить пользователя��$	��200��+  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��$��116,81,116,0q�$	��Top=��� $	��450�����	#FF1E283E$'��!Удаление вопросов��$��521,331,29,21q�.���� .+��� $��40��$	 
Horizontal=�  AttentionToActionBrush#��[ .+��� $��20��$��1�� J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~��� �� ��  �� Angle$	 -90Q�T� �� -    ��Name$ SelAll���� $��20��$��1��$ 0.5,0.5&�z�V� .~��� �� �� $	 -90Q�T� �� $��Вопросы��$��Center=�$��16(�
��������� -   $ Listing��$	��147��#��[ $��4q��� -   $O��IУдалить выбраные вопросы из базы данных��$	��400��$��15q�$ 10���� $	��450�����	#FF1E283E$0��*Заугрузить Базу Данных��$��29,452,521,21q�.���� .+��� -   $��FolderDB��$	��400��$��40��$��10q�$��10q�$��14(�
�������$0 *Путь к фалу базы данных�� �	#FF1E283E#��[  $��Center=��� $	 
Horizontal=�$	��400��$��0,10,0,0q�.+��� -   $��Выбрать файл��$	��195��$  ��$ 10��$��0,0,0,0q��� -   $+��%Сохранить изменения��$	��195��$ 10��$��10,0,0,0q��� $	��450�����	#FF1E283E$-��'Редактировать теорию��$��521,209,29,333q�.���� .+��� -   $J��DДобавление теоретических материалов��$	��400��$��7q�$ 10��