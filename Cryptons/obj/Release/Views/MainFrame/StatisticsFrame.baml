   M S B A M L   `   `   `  ���� C  ?Cryptons, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Cryptons.Views.MainFrameCryptons.Views.MainFrame  U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf .    (Cryptons.Views.MainFrame.StatisticsFrame   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    >d2http://schemas.microsoft.com/expression/blend/2008    6local&clr-namespace:Cryptons.Views.MainFrame    b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     &oxyhttp://oxyplot.org/wpf     Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf       N� Title$  StatisticsFrame��$	��650��$
��1000��.��� .+�#  LiveCharts.Wpf.CartesianChart  ���	#FF303030$��526,70,24,157q�&   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$
 None=�   Series �� *SeriesCollection+   AxisX   LiveCharts.Wpf.Axis     Title$ Студенты��   Labels �� *Labels+   AxisY   $ Оценка��   LabelFormatter �� *	Formatter+�� $	��432��$��29��$��	71,70,0,0q�$	��Top=�$
��Left=����	#FF303030 �� CornerRadius$ 5��&   System.Windows.Controls.DataGrid  -   	  Name$	 dataUser��$��71,104,497,157q�
   AutoGenerateColumns
 .     CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     CanUserResizeRows .  !   EnableColumnVirtualization .     EnableRowVirtualization .     
IsReadOnly .    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 170    Header$ Студент��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Name+  $	 100 $ Группа�� �� *Group+  $	 100 $ Оценка�� �� *Rating+�� -   $
��Stud��$��80,70,770,555q�)	  #MaterialDesignThemes.Wpf.HintAssist 	  Hint$ Студент��
������� 	  HintOpacity$	 .26Q�$��5,3,0,0q�$��14(��� -   $
��Grou��$��77��$��
254,70,0,0q�
�������$ Группа��$	 .26Q� �� 
IsEditable . $
��Left=�$	��Top=�$��25��.@��� $��ПЗ-17-1/9���� $��ПЗ-18-1/9���� $��ПЗ-19-1/9���� $��ПЗ-20-1/9���� -   $	��Rat��$��83��$��
356,70,0,0q�
�������$ Оценка��$	 .26Q� . $
��Left=�$	��Top=�$��25��.@��� $��1���� $��2���� $��3���� $��4���� $��5���� -   $
��Left=�$��
468,74,0,0q�$	��Top=�$��24��$��21��$��0q�.��'
  !MaterialDesignThemes.Wpf.PackIcon
   
  Kind$ ClearCircle=�