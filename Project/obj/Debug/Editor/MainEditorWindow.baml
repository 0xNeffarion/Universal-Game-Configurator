   M S B A M L   `   `   `  ����V  RUniversal Game Configurator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Universal_Game_ConfiguratorUniversal_Game_Configurator  5   	   9    3Universal_Game_Configurator.Editor.MainEditorWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:Universal_Game_Configurator     5   	   -   5          �Name$  mainEditWin��5   	    � Title$3 -Universal Game Configurator - Database Editor��5   	   $	��400��6?   $	��583��6L   &   System.Windows.Media.TextOptions   TextFormattingMode$ Display=�6X    � UseLayoutRounding .  � 
ResizeMode$ NoResize=�5	   "   $��13(�68   $	��515��6F   $	��380��6U   .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��530* �6   �� 5      $	��47* �6    � RowDefinitions 5   
   �� 5      $��55 �6   �� 5      $��45 �6   �� 5      $��45 �6   �� 5      $��45 �6   �� 5      $��46 �6   �� 5      $��0 �6   �� 5      $	��16* �6   �� 5      $	��28* �6   �� 5      $	��29* �6   �� 5      $	��42* �6   .+�5   
   �� -   5         ��Name$ btnEditGames��5      $��	10,8,10,5q�6'   $��Edit Games XML��6:   $��1��6S   $��SemiBold"�6`   $��2��6v   �� 5   
   -   5        $ btnEditGameConfig��5      $��	10,9,10,4q�6,   $��Edit Game Config XML��6?   $��2��6^   $��SemiBold"�6k   $��2��6�   �� 5   
   -   5        $ btnNewGameConfig��5      $��
10,10,10,3q�6+   $��New Game XML��6?   $��3��6V   $��SemiBold"�6c   $��2��6y   �� 5   
   -   5        $ btnEditDescriptions��5      $��
10,11,10,2q�6.   $��Edit Descriptions��6B   $��4��6^   $��SemiBold"�6k   $��2��6�   �� 5   
   $��0��6   $��UCG XML Database Editor��6!   $��Center=�6@    �� TextAlignment$ Center=�6[   $��Center=�5       $��18(�61   $��SemiBold"�6?    . $��10,16,10,10q�5!      $	��557��6)   $��2��65   $��29��6I   6W   �� 5#   
   -   5        	 ��Name$	 textBoxGamePath��5#      $
��Left=�6+   $��23��6F   $��7��6R   $��[EDIT] Games XML Path��6_   $	��Top=�6|   $��Center=�6�   
 �� 
IsReadOnly
 . $��10,5,0,0q�6�   $	��510��6�   �� 5$   
   -   5        $ buttonBrowse1��5$      $	��...��6(   $
��Left=�66   $��23��6Q   $��7��6]   $	��Top=�6j   $��33��6�   $��1��6�   $��5,5,0,0q�6�   
 � Tag$ 0��6�   �� 5%   
   -   5        $	 textBoxConfigEditPath��5%      $
��Left=�61   $��23��6L   $��8��6Y   $��[EDIT] Config XML Path��6f   $	��Top=�6�   $��Center=�6�   
 . $��10,5,0,0q�6�   $	��510��6�   �� 5&   
   -	   5        $ buttonBrowse2��5&      $	��...��6(   $
��Left=�66   $��23��6Q   $��8��6]   $	��Top=�6j   $��33��6�   $��1��6�   $��5,5,0,0q�6�   $ 1��6�   �� 5'   
   -
   5        $	 textBoxDescriptionPath��5'      $
��Left=�62   $��23��6M   $��9��6Y   $"��[EDIT] Descriptions XML Path��6f   $	��Top=�6�   $��Center=�6�   
 . $��10,5,0,0q�6�   $	��510��6�   �� 5(   
   -   5        $ buttonBrowse3��5(      $	��...��6(   $
��Left=�66   $��23��6Q   $��9��6^   $	��Top=�6k   $��33��6�   $��1��6�   $��5,5,0,0q�6�   $ 2��6�   5)      5*      