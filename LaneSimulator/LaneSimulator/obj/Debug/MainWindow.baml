   M S B A M L   `   `   `  ����H  DLaneSimulator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:LaneSimulator.Utilities.Selector LaneSimulator.Utilities.Selector  5	      A%clr-namespace:LaneSimulator.UtilitiesLaneSimulator.Utilities  5          LaneSimulator.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      d `Microsoft.Expression.Controls, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35>ec5http://schemas.microsoft.com/expression/2010/controls  5      =selector.clr-namespace:LaneSimulator.Utilities.Selector  5	      5	utilities%clr-namespace:LaneSimulator.Utilities  5      -   5          � Title$  Lane Simulator��5      $	��600��6   $	��850��6)    � Icon$ Images/ram.png��5       � WindowStartupLocation$ CenterScreen=�5       � 	Resources 5         TgButtonStyle �� 
TargetType �� Property �� Value �� Triggers �� Binding	 �� RelativeSource
 �� Path �� Value  TButtonStyle �� BasedOn��%�  &	        &	 �     7 ��� 5   
   " d�6&   .�5      ��  �@^�ShowOnDisabled . 6>    5      �� 5       6   �� 	 �� *Self+$
 	IsEnabled�	 False6g   .a�5      ��  �@J�Opacity$
 0.50Q�60   5      5      �� 5   
   " ��6%   8   .�5      ��  �@^�ShowOnDisabled . 6>    5       �� 5!       6   �� 	 �� *Self+$
 	IsEnabled�	 False6g   .a�5"      ��  �@J�Opacity$
 0.50Q�60   5#      5%      5'      .��5+      � -   5        $��Grid1��5+       � RowDefinitions 5,   
   �� 5-      $
��Auto �6   �� 5.      $��* �6   �� 5/      $
��Auto �6    � ColumnDefinitions 51   
   �� 52      $
��Auto �6   �� 53      $��* �6   .+�56   
   '   !LaneSimulator.Utilities.SSLCanvas  -   5          Name$ 	SSLCanvas��56      $��1��61   $��1��6A   5   /LaneSimulator.Utilities.Selector.ObjectSelector  58   
   -   5          Name$ SSLComponents��58   "   $��1��69   $��0��6F   �� 5:   
   -   5        $��spZoom��5:   K   $��0��6   $��0��6"    �� Orientation$ 
Horizontal=�62   .+�5;      �� $��Images/ZoomHS.png��6   $��20��6/   �� 5<      -   5        $��slZoom��5<       � Minimum$
 0.01Q�6#    � Maximum$ 5Q�62    � Value$ 1Q�6>    � SmallChange$
 0.01Q�6H    � LargeChange$	 0.1Q�5=       � ToolTip$ Adjust circuit zoom��6'   $��60��5>      $��20��6    6,   �� 5?      -   5        $��btnActualSize��5?   G   #��[ 6   $��20��6;   $ Zoom to Default Size��5@      .��5A      �� $��Images/ActualSizeHS.png��6   5B      �� 5C      -   5        $��btnFitToScreen��5C   G   #��[ 6   $��20��6;   $# Zoom to Fit Circuit in Window��5D   2   .��5E      �� $��Images/PageWidthHS.png��6   5F      5G      �� 5I   
   -	   5        $��traysCounter��5I   K   $��0��6   $��0��6"   $ 
Horizontal=�62   .+�5K      � $��96.907��6   $��138.264��6#   .+�5L      �� -
   5         ��Name$ textBox1_Copy1��5L      $��42.634��62   $��Center=�6B   $��Center=�5M      $��Total��6<   $+��%/WpfApplication1;component/Fonts/#LCD)�5N      ���	#FFB22121
���   �$��29.333(�5O   D   $��2q�6V   |�.   � Cursor$ Arrow��5Q      $	��Top=�6)   ��6A   Z� �� 5R      -   5        $ total_text1��5R      $��Center=�6/   $��Center=�6S   $��0��5S      $+��%/WpfApplication1;component/Fonts/#LCD)�5T      ���	#FFB22121
���   �$��48(�5U      $��2q�6(   |�.  $ Arrow��6N   $��0,36.09,0,0q�6]   ��5V      Z� 5W      5X      �� 5Z   
   -   5        $��Timer��5Z   K   $��0��6   $��0��6"   $ 
Horizontal=�62   .+�5[      �� ���	#FF539D3F$��2q�6-    �� CornerRadius$ 5��6A   $��56.911��6R   $��116.667��6b   ��5\      �� 5]       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5^      �  � Color$ 	#FFA1D8A5��6'    � Offset$ 0Q�69   � 5_      $ White��6'   $ 1Q�65   5`      ._�5b      �� -   5         ��Name$ Timer_Lable��5b      $+��%/WpfApplication1;component/Fonts/#LCD)�61   $��48(�6d   $	��0.0��5c        �� TextAlignment$  Center=�5d      $
��Wrap=�63   ���	#FF9F23236G   5e      5f      �� 5h   
   -   5        $��Counter��5h   K   $��0��6   $��0��6"   $ 
Horizontal=�62   .+�5j      � $��96.907��6   $��138.264��6#   .+�5k      �� -   5        $ MouseClickOfUser��5k      $��Center=�64   $��Center=�6X   $��0��5l      ���	#FFB22121
���   �$��48(�5n      $��2q�6(   |�.  $��0,36.09,0,0q�6N   ��5o      Z� �� 5q      -   5        $ textBox1_Copy2��5q      $��42.634��62   $��Center=�6B   $��Center=�5r      $��Trays��5s      ���	#FFB22121
���   �$��29.333(�5t   D   $��2q�6V   |�.  $	��Top=�5v      ��62   Z� 5w      5x      �� 5{   
   -   5        $��Status��5{   K   $��0��6   $��0��6"   $ 
Horizontal=�62   .+�5}      � $��96.907��6   $��138.264��6#   .+�5~      �� -   5        $ 
StatusName��5~      $��42.634��6.   $��Center=�6>   $��Center=�5      $��Lane Status��5�      ���	#FFB22121
�������$��25(�5�   D   $��2q�6R   |�.  $	��Top=�5�      ��62   Z� �� 5�      -   5        $ LaneStatusName��5�      $��Center=�62   $��Center=�6V   
����  �
�������$��15(�5�      $��2q�6(   |�.  $��0,36.09,0,0q�6N   ��5�      Z� 5�      5�      �� 5�   
   -   5        $��ButtonsPanel��5�   2   $��0��6   $��0��6"   $ 
Horizontal=�6F   .+�5�      �� -   5        $��Play_Button��5�   1   $��68��5�      $
 Play��6    {�. .��5�      �� $��51.072��6   $��Images/Play1Hot.png��6(   $
��Fill=�6E   $��51.072��6T   5�      5�   
   �� 5�   
   -   5        $��DegradedPanel��5�   2   $��0��6   $��0��6"   $ 
Horizontal=�6G   .+�5�      �� -   5        ! ��Name$! NotApproved��5�   1   $��68��5�      $ 
Disapprove��6    {�. .��5�      �� $��51.072��6   $%��/Images/push-button-red-512.png��6(   $
��Fill=�6Q   $��51.072��6`   5�      �� 5�      -   5        $��Approvel��5�   .   $��68��5�      $ Approve��6    {�. .��5�      �� $��51.072��6   $'��!/Images/push-button-green-513.png��6(   $
��Fill=�6S   $��51.072��6b   5�      5�      `� 5�   
   $��0��6   $��2��6#   $��0��67   .�5�      c� -   5        $��
tbPrinting��5�   "   $��40��6   .@�5�      �� -   5        $��btnChart��5�   ?   #��[ 6   $ Show Scheduler��5�      .��5�      �� $3��-Images/logicity-crystal-reports-scheduler.png��6   5�      5�      5�      �� 5�   
   -   5        $! 	Generator��5�   -   $��50��6@   $��50��5�      $ Trays��6   $
 Hand��6,   .��5�      �� $��25��6   $��Images/tray_object.png��6    $
��Fill=�6@   $��30��6O   5�      �� 5�   
   -   5        $��	spAppInfo��5�      $��2��6&   $��2��63   $ 
Horizontal=�6G   ���#EEEEEE.+�5�      �� -   5        $��lblAppTitle��5�      $��10,0,0,0q�6+   �� 5�      -   5        $��lblAppVersion��5�      $��10,0,0,0q�6-   �� 5�      -   5        $��lblAppCopyright��5�      $��10,0,0,0q�6/   �� 5�      -    5        $��lblLink��5�      $��10,0,0,0q�6(   6<   5�      �� 5�   
   -!   5        $��lblInfoLine��5�      ���#EEEEEE$��2��6<   $��2��6I   " �� Padding$" 10,0,0,0q�6^   $y�Hidden=�6q   �� 5�   
   -"   5        # ��Name$# adornerLayer��5�      $y�	Collapsed=�6'   5�      5�      