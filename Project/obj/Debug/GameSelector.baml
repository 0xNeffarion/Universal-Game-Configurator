   M S B A M L   `   `   `  ����V  RUniversal Game Configurator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Universal_Game_ConfiguratorUniversal_Game_Configurator  5   	   c6clr-namespace:Universal_Game_Configurator.Objects.Data(Universal_Game_Configurator.Objects.Data  5   	   _4clr-namespace:Universal_Game_Configurator.Converters&Universal_Game_Configurator.Converters  5	   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5
   	   .    (Universal_Game_Configurator.GameSelector   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:Universal_Game_Configurator     5   	   X TXceed.Wpf.Toolkit, Version=3.1.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   Adata6clr-namespace:Universal_Game_Configurator.Objects.Data  5   	   E
converters4clr-namespace:Universal_Game_Configurator.Converters  5	   	   YwiPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity  5
   	   h dMicrosoft.Expression.Interactions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  5   	   -   5          �Name$  GameSelectionWindow��5   	    � Title$2 ,Universal Game Configurator - Game selection��5   	   $	��579��6>   $	��615��6K    � Icon$ Resources/UGC_Icon.ico��5   	    � WindowStartupLocation$ CenterScreen=�6'   &   System.Windows.Media.TextOptions   TextFormattingMode$ Display=�6L   $	��320��5   	   $	��460��6    � UseLayoutRounding . $��	Open Sans)�6A    � WindowStyle$
 None=�5   	    � AllowsTransparency .  � 
ResizeMode$ CanResizeWithGrip=�6L   	 � DataContext$	 GameViewModel��5   	   ��5   6   Z� 
 � 	Resources
 5       ,  (ListViewItemSelectedBackgroundThemeBrush �� Color  myHeaderStyle �� 
TargetType �� Property �� Value  	borderRem(  "Xceed.Wpf.Toolkit.WatermarkTextBox �� Triggers P� Property P� Value  myListViewStyle �� 	Resources��%�  &	        &	      &	 m     &	 )    �� 5   
   $
 Gray��6K   �� 5   
   " ��6&   .�5      ��  � y�$ 	Collapsed=�6+   5      �� 5   
   "  6"    5      P� 5       �@J�	IsFocused . . �5      ��  � �� �	#3FABADB36H   5      .�5      ��  � �� �	#3FABADB36@   5      �� 5   
    5       ���� 5!      $ 	#FFACD3DE��6T   (��       6"   * SystemColors.HighlightBrushKey+)6T   �� 5"      $ White��6R   (��       6"   *SystemColors.ControlBrushKey+)6R   �� 5#      $ Black��6X   (��       6"   *$"SystemColors.HighlightTextBrushKey+)6h   5$      5%      5&      .��5'      ��  �� CornerRadius$ 5��6     WindowBackgroundBrush#���  6   ���	#FF555555$��1q�6k   ._�5(   
   �  � ColumnDefinitions 5)      �� 5*      �� 5+      $��32 �6#   �� 5,      $��24 �6#   �� 5-      $��34 �6#    � RowDefinitions 50      �� 51      $��29 �6    6.   �� 52      $��38 �6    �� 53      $��41 �6    �� 54      $	��74* �6    �� 55      $
��139* �6    �� 56      $
��177* �6    .+�58      ]� -   5         ]�Name$ titleBorder��58      $��4��6-   ���	#FF424242.+�59      �� $
��Left=�6    �� Orientation$ 
Horizontal=�68   $��Center=�6Q   $��10,0,0,0q�6l   .+�5:      �� -   5         ��Name$ windowTitle��5:       
������� � ForceCursor . $��SemiBold"�6�   $��14(�6�   $��Center=�6�   ��65   �� *Title+ �� RelativeSource �� *FindAncestor+ �� AncestorType" �6�   5;      �� 5<      $��Right=�6   $ 
Horizontal=�69   $��Center=�6R   $��0,0,4,0q�6m   $��Right=�6~   .+�5=      �� -   5         ��Name$ btnMinimizeWindow��5=      $��Marlett)�68   $��0��6M   $��1,1,4,1q�6Y   $��Center=�6j   $	��7,4q�6�   $
��Bold"�5>      
���������5?      �� *MinimizeWindowCommand+��5@      ��  �� ElementName$ GameSelectionWindow���� 5A      -   5        $ btnCloseWindow��5A      $��Marlett)�65   $��r��6J   $��1q�6V   $��Center=�6a   $	��7,4q�6|   $
��Bold"�6�   
����������	#FFCB2626��5C      �� *CloseWindowCommand+��5D      �� $ GameSelectionWindow��5E      5F      �� 5G      -   5         ��Name$ GamesListView��5G      $��4��6.   $��0��6B   $��3��6R   $��
10,5,10,20q�6c   $��3��6w   $��Visible=�6�   $��Disabled=�5H      $��0,0,0,6q�6M    �� SelectionMode$ Single=�6_   ���	#FFFBFBFB
�������$��0q�5I   /   ��6C   Z� ��6Y   �� *Games+  �� SelectedIndex  6w   �� *SelectedGameIndex+
 5J        	TextBrush  ListViewItemFocusVisual! �� 
TargetType" � 	Resources  Key# g� 	BeginTime$ �� 
TargetName% �� TargetProperty& O� KeyTime' O� Value( ��Name) J� SnapsToDevicePixels* ��Name+ J� IsHitTestVisible, J� Opacity  NormalBrush- �� RadiusX. �� RadiusY/ �� EndPoint0 �� 
StartPoint1 � Color2 � Offset3 �� Triggers4 N� ExitActions5 ��Name 	 SelectedOff6 N� EnterActions 
 
SelectedOn  HoverOff  HoverOn7 ]� 
Conditions8 �� Property9 �� Value  DisabledForegroundBrush: �� 
TargetName  DisabledBackgroundBrush  
BlackColor��%$  '��       7 	 7 
 7  7  �� 5K      " ��6   .�5L      ��  � ��# �  67   �� 5M       �@�FocusVisualStyle# �  6=   �� 5N       � ��$ Stretch=�6G   �� 5O       � �� 5P      �� 5Q   "   "! ��62   " 5R   &   ���� 5S   *   HoverOn .��5T   .   U� $# 00:00:00X�6L   $$ HoverRectangle��6a   $% (UIElement.Opacity)�6�   .\�5U   2   �� $& 00:00:00.1000000��6G   $' 1Q�6b   5V   /   5W   +   �� 5X   *   HoverOff .��5Y   .   U� $# 00:00:00X�6L   $$ HoverRectangle��6a   $% (UIElement.Opacity)�6�   .\�5Z   2   �� $& 00:00:00.4000000��6G   $' 0Q�6b   5[   /   5\   +   �� 5]   *   
SelectedOn .��5^   .   U� $# 00:00:00X�6L   $$ SelectedRectangle��6a   $% (UIElement.Opacity)�6�   .\�5_   2   �� $& 00:00:00.1000000��6G   $' 1Q�6b   5`   /   5a   +   �� 5b   *   SelectedOff .��5c   .   U� $# 00:00:00X�6L   $$ SelectedRectangle��6a   $% (UIElement.Opacity)�6�   .\�5d   2   �� $& 00:00:00.4000000��6G   $' 0Q�6b   5e   /   5f   +   �� 5g   *   
FocussedOn .��5h   .   U� $# 00:00:00X�6L   $$ FocusVisualElement��6a   $% (UIElement.Opacity)�6�   .\�5i   2   �� $& 00:00:00.1000000��6G   $' 1Q�6b   5j   /   5k   +   �� 5l   *   FocussedOff .��5m   .   U� $# 00:00:00X�6L   $$ FocusVisualElement��6a   $% (UIElement.Opacity)�6�   .\�5n   2   �� $& 00:00:00.3000000��6G   $' 0Q�6b   5o   /   5p   +   5q   '   .R�5r   &   �� $( border��6�   ) . #��z��6H   #��z��6t   $ 2��6�   ._�5s   *   � $��0q�6/   .+�5t   .   �� $* 
Background��68   + . $
, 0.25Q�6d   #���  6s   $- 1��6�   $. 1��6�   �� 5u   .   $* HoverRectangle��68   + . $, 0Q�6h   #���  6t   $- 1��6�   $. 1��6�   �� 5v   .   $* SelectedRectangle��68   + . $, 0Q�6k   $- 1��6w   $. 1��6�   ��5w   2   �� 5x   6   $/ 0.5,1&�6J   $0 0.5,0&�6[   .��5y   :   � $1 	#F26E6E6E��6G   $2 1Q�6Y   � 5z   :   $1 	#F2DCDCDC��6G   $2 0Q�6Y   5{   7   5}   /   �� 5~   .   #) z) 6C   $��0q�6   $��Stretch=�6�   5   +   5�   '   3 5�   &   P� 5�   *    �@��
IsSelected . 4 5�   .   �� 5�   2   $!5 SelectedOff_BeginStoryboard��6l   8��  6 5�   .   �� 5�   2   $ 5 SelectedOn_BeginStoryboard��6k   8�� 5�   +   ]� 5�   *   4 5�   .   �� 5�   2   $5 HoverOff_BeginStoryboard��6i   8�� 6 5�   .   �� 5�   2   8�� 6B   7 5�   .   �� 5�   2   8 �@J�IsMouseOver9 . 6S   �� 5�   2   8 �@��
IsSelected9 .  6[   5�   +   ]� 5�   *   7 5�   .   �� 5�   2   8 �@��
IsSelected9 . 6[   �� 5�   2   8 �@J�IsMouseOver9 . 6S   5�   +   P� 5�   *    � {� .  . �5�   .   �� # �  6K    � ���� 5�   .   $: 
Background��6E   # �  6]    � ��5�   +   ]� 5�   *   7 5�   .   �� 5�   2   8 �@��
IsSelected9 . 6R   �� 5�   2   8 �@��IsSelectionActive9 .  6b   5�   +   5�   #   5�       5�      P� 5�       �@��
IsSelected . . �5�   "   ��  � �� 5�   &   �� 5�   *   # �  6:   5�   #   5�      5�      5�      ; �� View; 5�      �� 5�      -   5        dataGridView��!< �� ColumnHeaderContainerStyle#< [ 5�   5   = �� AllowsColumnReorder= .  .P�5�      �� -   5        GridCol1��$��Installed game��5�   ;   > �� CellTemplate> 5�      �� 5�   "   .R�5�   &   �� $ 
Horizontal=�61   .+�5�   *   �� $��6q�61   ���	#FF747474$��1q�6T   $��65��6h   $��65��6s   $ 9��6   $
��Left=�6�   $��Center=�6�   ._�5�   .   �� ? ��Name$? imgGameIcon��6b   @ �� BitmapScalingMode$@ HighQuality=�64   $��65��6w   $��65��6�   $��UniformToFill=�6�   ��5�   4   �� A �� Path$A 	ImageName�?   9Universal_Game_Configurator.Converters.GameImageConverterB   InstanceC �� 	Converter#C ZB D J� ClipD 5�   2   �� 5�   6   E �� RadiusX$E 9Q�6H   F �� RadiusY$F 9Q�6T   G �� Rect$G 	0,0,64,64�6`   5�   /   5�   +   �� 5�   *   $ txtGameName��64   $��Center=�6I   $��Center=�6d   $��16(�6�   $
��Bold"�5�   4   $��15,0,0,0q�6F   $��WordEllipsis=�6X   ��5�   4   �� *Name+6L   5�   '   5�   #   5�      �� 5�      -	   5        GridCol2��$��Genre��5�   ;   > 5�      �� 5�   "   .R�5�   &   �� $ 
Horizontal=�61   $��Center=�6J   .+�5�   *   �� $ txtGameType��64   $��Stretch=�6I   $��14(�6e   $��SemiBold"�6s   $��0q�6�   $��Center=�6�   H �� TextAlignment$H Center=�5�   0   $��CharacterEllipsis=�6G   $ Display=�6h   ��5�   0   �� $A GenreObj�<   6Universal_Game_Configurator.Converters.GenresConverterI   Instance#C ZI 6�   5�   '   5�   #   5�      �� 5�      -
   5        GridCol3��$�� ��5�   ;   > 5�      �� 5�   "   .R�5�   &   �� $ 
Horizontal=�61   $��Center=�6J   .+�5�   *   �� $? imgNext��60   $��Center=�6A   $��24��6\   $��24��5�   ,   $#��Resources/arrow_goforward.png��68   J � Cursor$
J Hand��6_   K � ToolTip$K 	Configure��6m   + . $��0,0,5,0q�5�   H   .  (System.Windows.Interactivity.InteractionL   TriggersL 5�   .   /  )System.Windows.Interactivity.EventTrigger  5�   2   M   	EventName$M 	MouseDown��6B   .  (System.Windows.Interactivity.TriggerBaseN   Actions.N 5�   6   6  0System.Windows.Interactivity.InvokeCommandAction  O   CommandParameterO 6M   �� $ GameSelectionWindow��P   CommandP 5�   L   ��  �� *FindAncestor+" �$"A DataContext.ConfigureCommand�5�   3   5�   +   5�   '   5�   #   5�      5�      5�      �� 5�      -   5        $ 	TitleText��5�      $
��Wrap=�6+   $#��Select the game to configure:��6?   $��1��6d   $��4��5�      $��0��6(   $H Center=�68   $��Center=�6O   $��17(�6j   $��SemiBold"�6x   $��23��6�   $��0,15,0,0q�6�   ���	#FFE0E0E06�   ]� 5�      $��5��6   $��0��6%   $��4��65   �� 5�      $��
10,10,20,5q�6   $��2��6)   $��0��66   $��1q�6F   ���	#FF898989$��4��6r   ._�5�        -   5        Q  Name$Q txtBoxSearch��5�   K   #��[ 6(   R �� TextWrapping$
R Wrap=�6b   $��26��6v   $��Center=�6�   
�������$��Center=�5�   b   $��0q�6�   ��6�   Z� .��6�   S   	WatermarkS 5�      �� 5�      $ 
Horizontal=�6%   .+�5�      �� $��Resources/magnifier.png��6$   $��16��6E   $��16��6P   $��Uniform=�6\   �� 5�      $��Search installed games...��6(   $��4,2,0,0q�6I   ���	#FFF0F0F06Z   5�      .��5�   7   5�      5�      �� 5�      -   5        $? 
imgRefresh��5�      $��3��6(   $��1��68   $"��Resources/arrows_refresh.png��6E   $��10q�6k   $
J Hand��6w   $K Refresh list��5�      $@ HighQuality=�6+   L 5�        5�      $M 	MouseDown��6&   .N 5�      >	  8Microsoft.Expression.Interactivity.Core.CallMethodAction	  T 	  
MethodName$T GetGames��5   !   U 	  TargetObjectU 5�   !   �� 5   !   5     5     �� 5     -   5        $? imgDownloadDb��5     $��2��6+   $��1��6;   $��Resources/db_update.png��6H   $
��4,11q�6i   $
J Hand��6w   $(K "Download database and refresh list��5     $@ HighQuality=�6A   $y�Visible=�6o   $��16��6�   $��Center=�6�   $��Center=�6�   $��16��6�   L 5       5     $M 	MouseDown��6&   .N 5     	  $T ForceUpdatesAndGames��5
  !   U 5	  !   �� 5
  !   5     5     �� 5     -   5        $? 	imgEditDb��5     $��1��6'   $��1��67   $��Resources/db_edit.png��6D   $��0,9,5,9q�6c   $
J Hand��6t   $K Open ucg database editor��5     $@ HighQuality=�67   $y�	Collapsed=�6e   L 5       5     $M 	MouseDown��6&   .N 5     	  $T OpenDatabaseEditor��5  !   U 5  !   �� 5  C   5     5     5     5     5     