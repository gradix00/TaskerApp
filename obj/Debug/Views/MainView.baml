   M S B A M L   `   `   `  ����E  AMvvmTasker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MvvmTasker.ViewsMvvmTasker.Views  5   	       MvvmTasker.Views.MainView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:MvvmTasker.Views     5   	   $	��350��5	   	   $	��500��6     � WindowStartupLocation$  CenterScreen=�6(    � Title 5   	   ��  �� Path$ Title� �� Mode$ OneWay=�.��5
      �  � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      .+�5   
   �� -   5         ��Name$ 	OpenTasks��5   9      RoundedButton#���   6   $��Taski��5      
����d�
�������$��2q�5      �� 5   
   -   5        $ OpenCreatorNewTask��5      $��1��5      #���   5      $��	Nowy task��5      
����d�
�������$��2q�5       �� 5"   
   -   5         ��Name$ 
ActiveItem��5"      $��0��6-   $��1��6=   $��2��6J   5#      5$      