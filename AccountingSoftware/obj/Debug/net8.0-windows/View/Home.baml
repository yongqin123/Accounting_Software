   M S B A M L   `   `   `  ����U  QScottPlot.WPF, Version=5.0.55.0, Culture=neutral, PublicKeyToken=86698dc10387c39eD2clr-namespace:ScottPlot.WPF;assembly=ScottPlot.WPFScottPlot.WPF  5      M IAccountingSoftware, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:AccountingSoftwareAccountingSoftware 5         AccountingSoftware.Home   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      H	ScottPlot2clr-namespace:ScottPlot.WPF;assembly=ScottPlot.WPF     5      2local clr-namespace:AccountingSoftware     5        N� Title$
  Home��5
      .��5      � -   5        $
��grid��5       � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      $	��800 �6   .+�5   
   �� -   5        $��	stackLeft��5      $	��200��6&   $��0��62   .+�5      �� $��/Images/logo.png��6   $	��100��6.   $	��100��6;   $��0,40,0,0q�6G   � 5      $��0,40,0,0q�6   .+�5      �� $��/Images/home.png��6   $��30��62   $��30��6=   $
��Left=�6I   $��40,0,0,0q�6d   �� 5      -   5        $
��home��5      $��
Go To Home��6%   $	��150��6M   $��Right=�6Y   $��0,0,0,0q�6u   
����� �
������ 6�   5      � 5      .+�5      �� $��/Images/add.png��6   $��30��61   $��30��6<   $
��Left=�6H   $��40,0,0,0q�6c   �� 5      -   5        $��
addAccount��5      $��Add Account��6+   $	��150��6Z   $��Right=�6f   $��0,0,0,0q�6�   
����� �
������ 6�   5      � 5      .+�5      �� $��/Images/show.png��6   $��30��62   $��30��6=   $
��Left=�6I   $��40,0,0,0q�6d   �� 5      -   5        $��viewAccount��5      $��View Account��6,   $	��150��6]   $��Right=�6i   $��0,0,0,0q�6�   
����� �
������ 6�   5       � 5!      .+�5"      �� $��/Images/add.png��6   $��30��61   $��30��6<   $
��Left=�6H   $��40,0,0,0q�6c   �� 5#      -   5        $��journalEntry��5#      $��Journal Entry��6-   $	��150��6`   $��Right=�6l   $��0,0,0,0q�6�   
����� �
������ 6�   5$      � 5%      .+�5&      �� $��/Images/notes.png��6   $��30��63   $��30��6>   $
��Left=�6J   $��40,0,0,0q�6e   �� 5'      -   5        $	��sfp��5'      $	��SFP��6$   $	��150��6D   $��Right=�6P   $��0,0,0,0q�6l   
����� �
������ 6�   5(      � 5)      .+�5*      �� $��/Images/notes.png��6   $��30��63   $��30��6>   $
��Left=�6J   $��40,0,0,0q�6e   �� 5+      -   5        $	��sci��5+      $	��SCI��6$   $	��150��6D   $��Right=�6P   $��0,0,0,0q�6l   
����� �
������ 6�   5,      � 5-      .+�5.      �� $��/Images/logout.png��6   $��30��64   $��30��6?   $
��Left=�6K   $��40,0,0,0q�6f   �� 5/      -	   5        $��logout��5/      $��Logout��6'   $	��150��6M   $��Right=�6Y   $��0,0,0,0q�6u   
����� �
������ 6�   50      51      �� 52   
   -
   5        $��
stackRight��52      $	��800��6'   $��1��63   .+�53         ScottPlot.WPF.WpfPlot  -   5        $��WpfPlot1��53       $	��500��60   $	��500��6<   $��0,60,0,0q�6I   
������ $��30(�6t   54      57      58      