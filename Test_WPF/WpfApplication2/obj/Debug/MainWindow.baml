   M S B A M L   `   `   `  ����J  FWpfApplication2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication2WpfApplication2  5   
        WpfApplication2.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   /localclr-namespace:WpfApplication2     5   
     � Title$"  StyleTriggerEnterExitActions��5   	   $
��1025��6.   $
��1025��6<    � UseLayoutRounding .  � 	Resources 5      "   WpfApplication2.ObjectToMove �� 
TargetType   object_style �� 	Resources  Key g� RepeatBehavior g� Duration T� Source �� TargetProperty	 T� PathGeometry
 �� Triggers :� RoutedEvent 
 Weeeee �� Property �� Value��%   &	        7  �� 5   
   "  6    5	      ���� 5      
Weeeee $ Forever��6,   .��5      T� $ 0:0:3D�5      $ X=�5      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�5      	 5      B� 5      $����M0.83299852,-4.019 L0.83299852,0.6089829 L0.61794496,0.94214186 C-7.6701996,14.489389 -12.443,30.392629 -12.443001,47.403001 C-12.443,96.887715 27.948303,137.003 77.773499,137.003 C113.58536,137.003 144.52365,116.27938 159.09367,86.248303 L159.90265,84.471135 L380.931,84.471135 L380.931,86.871121 L160.63918,86.871121 L160.4838,87.217053 C145.62575,118.25356 114.07582,139.671 77.556,139.671 C26.745804,139.671 -14.444,98.212666 -14.444,47.071218 C-14.444,29.491346 -9.5768454,13.055669 -1.124851,-0.94513857 zC�6+   5      T� 5      $ 0:0:3D�6/   $ Y=�6@   $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6K   	 5      B� 5      $����M0.83299852,-4.019 L0.83299852,0.6089829 L0.61794496,0.94214186 C-7.6701996,14.489389 -12.443,30.392629 -12.443001,47.403001 C-12.443,96.887715 27.948303,137.003 77.773499,137.003 C113.58536,137.003 144.52365,116.27938 159.09367,86.248303 L159.90265,84.471135 L380.931,84.471135 L380.931,86.871121 L160.63918,86.871121 L160.4838,87.217053 C145.62575,118.25356 114.07582,139.671 77.556,139.671 C26.745804,139.671 -14.444,98.212666 -14.444,47.071218 C-14.444,29.491346 -9.5768454,13.055669 -1.124851,-0.94513857 zC�6+   5      5      5      
 5      :� 5       $ FrameworkElement.Loaded��6   .[�5!      �� 8��  6&   5"      .�5&      ��  �@J�RenderTransformOrigin$ 0.5,0.5&�66   �� 5'       � z� 5(      V� 5)      .~�5*      �� �� 5+      �� 5,      T� 5-      5.      50      52      53      .��55      �� -   5         ��Name$
 Main��55      $
��1025��6   $
��1025��6)   z�57   
   u� 58       u� Matrix$( "1.25 0 0 -1.25 -197.1231 961.58875x�6   .+�5;   
   F� :x,http://schemas.microsoft.com/winfx/2006/xaml     6   -   5        $��
path139746��5;   F   ���	#FFD3BC5F �� Left$ 399.4��6i   
 �� Top$ -172.6��6}   ��5<      B� 5=      $����m 66.611178 552.33853 c -4.36996 0.6305 -8.8334 0.97293 -13.3752 0.97293 -18.11465 0 -35.027 -5.21161 -49.34949 -14.18974 l 21.64732 -36.67733 c 8.2963 5.25686 18.12667 8.31294 28.67512 8.31294 2.7121 0 5.37755 -0.20365 7.98106 -0.59283 l 2.23539 -0.38916 c 4.72288 -0.91109 9.2226 -2.43913 13.41755 -4.49964 l 35.933612 77.65818 c -12.53504 5.94167 -26.095762 10.06571 -40.347392 12.0342 0 0 -2.27764 -21.55688 -4.54327 -42.98252 l -2.2747 0.35297 zC�6    B� FillRule$ nonzero=�6�  5?      F� 5@   
   :x,http://schemas.microsoft.com/winfx/2006/xaml     6   ���	#FFD3BC5F$	 401��6W   $
 -173��6i   ��5A      B� 5B      -   5        
path139750��$����m -21.311892 515.98804 c -11.7053 -15.57594 -18.6547 -34.92004 -18.6622 -55.85694 l 35.53987 0 5.06525 -0.024 c 0.63507 11.4535 4.86922 21.94 11.58023 30.3706 l 1.44647 1.7423 c 2.94008 3.3894 6.29329 6.4077 9.98888 8.9736 l -43.53754 73.76488 c -13.18956 -8.30539 -24.88746 -18.76176 -34.60186 -30.87743 0 0 17.3968 -13.23944 34.61076 -26.3386 l -1.42986 -1.75428 zC�5B   3   $ nonzero=�6�  5D      F� 5E   
   :x,http://schemas.microsoft.com/winfx/2006/xaml     6   -   5        $��
path139780��5E   F   ���	#FFD3BC5F$ 401.4��6i   $ -167.6��6}   ��5F      B� 5G      $J��Dm 214.75854 460.1016 94.92962 0 0 69.86866 -94.92962 0 0 -69.86866 zC�6   $ nonzero=�6n   5I      F� 5J   
   :x,http://schemas.microsoft.com/winfx/2006/xaml     6   -   5        $��
path139784��5J   F   ���	#FFD3BC5F$ 401.4��6i   $ -167.6��6}   ��5K      B� 5L      $c��]m 211.64803 529.825 -36.87191 0 -62.32503 -69.72236 100.95576 0 0 69.74499 -1.75882 -0.0226 zC�6   $ nonzero=�6�   5N      F� 5O   
   :x,http://schemas.microsoft.com/winfx/2006/xaml     6   ���	#FFD3BC5F$
 -173��6X   $	 401��6j   ��5P      B� 5Q      -   5        
path139798��$����m -41.482092 460.131 -43.5377 0 c 0.6744 30.93022 11.4414 59.36853 29.1278 82.17137 l 33.3799 -25.40184 c -11.9001 -15.82789 -18.9641 -35.4887 -18.97 -56.76953C�5Q   3   $ nonzero=�6�   5S      F� 5T   
   :x,http://schemas.microsoft.com/winfx/2006/xaml     6   -   5        $��
path139802��5T   F   ���	#FFD3BC5F$ 399.4��6i   $ -172.6��6}   ��5U      B� 5V      $����m 139.82292 494.54117 c -13.01467 -14.5593 -25.97803 -29.06131 -30.40076 -34.00892 0 0 -2.72123 28.49563 -29.566602 43.70507 l 17.54746 37.92328 c 19.158502 -10.35383 34.278952 -27.22704 42.419902 -47.61943C�6   $ nonzero=�6�   5X      F� 5Y   
   :x,http://schemas.microsoft.com/winfx/2006/xaml     6   -   5        $��
path139806��5Y   F   ���	#FFD3BC5F$ 399.4��6i   $ -172.6��6}   ��5Z      B� 5[      $����m 98.037008 543.53024 17.776782 38.41802 c 23.1211 -11.42479 42.62202 -29.06882 56.29587 -50.76297 l 0.18403 -0.31676 c 0 0 -15.53072 -17.37553 -31.34655 -35.06934 -8.34762 20.43762 -23.62341 37.33197 -42.910132 47.73105C�6   $ nonzero=�6  5]      F� 5^   
   :x,http://schemas.microsoft.com/winfx/2006/xaml     6   -	   5        $��
path139810��5^   F   ���	#FFD3BC5F$ 399.4��6i   $ -172.6��6}   ��5_      B� 5`      $����m 53.235488 554.82033 c -18.39362 0 -35.56859 -5.28853 -50.11595 -14.3994 l -21.08756 35.73002 c 21.04842 12.78086 45.75185 20.14348 72.17809 20.14348 5.74697 0 11.40815 -0.36201 16.97265 -1.03931 l -4.37747 -41.4213 c -4.43321 0.63805 -8.96144 0.98651 -13.56976 0.98651C�6   $ nonzero=�68  5b      F� 5e   
   �����^� @B �^� O�U �&���0@�B�5�@���!_@��)�dN<@�V��- r���dN<@ �/�pw�b�pw��԰pw��	��:�;g
�p�ړs
؂U��3�؂U��3��!z���~
�!z��q|
iӶ��	p�X�y�]�0`@P˟@�P˟��ÃP˟�0'j��@B 
��M`�w@.�-~� �[Y�K@	���	#7F000000$��145.69��6�  $ 360.056��6   �� Stretch$
 Fill=�6  
���  ��$��2��69  $ 236.648��6M  $��397.375��6b  �� 5f   
   -
   5        $��Button��5f      $	 513��6"   $	 696��64   $��75��6E   6P     5j   
   -   5          Name$
 Tray��5j      $	 356��6+   $	 218��6=   $��31��6N   $��45��6Z   6g   5m      5s      