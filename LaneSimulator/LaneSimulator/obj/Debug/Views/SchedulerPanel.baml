   M S B A M L   `   `   `  ����  LaneSimulator(    "LaneSimulator.Views.SchedulerPanel   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Scheduler Panel��5   	   $	��150��6!   $	��300��6.    � 
ResizeMode$ NoResize=�6:    � WindowStartupLocation$ CenterScreen=�6Q    � Icon$6 0../Images/logicity-crystal-reports-scheduler.png��6w   .��5      �  � ColumnDefinitions 5   
   �� 5	      $
��Auto �6   �� 5
      $��* �6   �� 5      $
��Auto �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��10,10,10,10q�6   .��6%   How many Trays?66   �� 5   
   -   5        $��	bitSlider��5   6   $��1��6   $��10,10,10,10q�6!    � Minimum$ 1Q�6G    � Maximum$	 100Q�6S    � Value$ 10Q�6a   	 � SmallChange$	 1Q�6l   
 � LargeChange$
 1Q�6|    �� IsSnapToTickEnabled .  �� TickFrequency$ 1Q�6�   �� 5   
   -   5        $��lblBits��5   5   $��2��6   $��10,10,10,10q�6    ��6D   ��  �� ElementName$ 	bitSlider�� �� Path$ Value�5      �� 5   
   -   5        $��btnOK��5   ^   $��0��6   $��1��6!   $��Right=�6.   $��
10,0,10,10q�6J   $��75��6k    �� 	IsDefault . .��6�   Start6�   �� 5   
   -   5        $��	btnCancel��5   ]   $��1��6   $��1��6!   $
��Left=�6.   $��
10,0,10,10q�6I   $��75��6n    �� IsCancel . .��6�   Cancel6�   5      5      