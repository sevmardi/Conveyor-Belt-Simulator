   M S B A M L   `   `   `  ����  LaneSimulator1    +LaneSimulator.Utilities.ShadowBox.ShadowBox   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        � 	Resources  5       �� 
TargetType   	FadeStyle �� Property �� Value �� Triggers :� RoutedEvent �� TargetProperty	 W� To g� Duration��%�  &	        �� 5   
   " ��6   .�5      ��  �@J�Opacity$	 0.2Q�6(    5	      :� 5
      $ Border.MouseEnter��6   .[�5      �� .��5      �� .��5      W� $ Opacity�5   !   $	 0.8X�5   !   $ 0:0:0.25D�6*   5      5      5      :� 5      $ Border.MouseLeave��6   .[�5      �� .��5      �� .��5      W� $ Opacity�5   !   $	 0.2X�5   !   $ 0:0:0.5D�6*   5      5      5      5      5!      .��5#      �� -   5        $��OuterBorder��5%   0   $��Center=�5#      $��Center=�6*   
��� ���$��3q�6Z   	 �� CornerRadius$	 10��5$      
 �� Padding$
 2q�6   #��[  5%      ._�5'   
   � -   5        $��Grid1��5'      .+�5)      �� -   5        $
��Mask��5)      
�������$	 7��64   �� 5,      -   5        $��	SpContent��5,       �� Orientation$ 
Horizontal=�6*    J� OpacityMask 5.      !� 5/       !� Visual 6"   ��  �� ElementName$
 Mask��53      55      56      59      