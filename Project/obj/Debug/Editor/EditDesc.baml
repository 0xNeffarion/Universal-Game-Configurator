   M S B A M L   `   `   `  ����V  RUniversal Game Configurator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Universal_Game_ConfiguratorUniversal_Game_Configurator  5   	   I)clr-namespace:Universal_Game_ConfiguratorUniversal_Game_Configurator  5   	   1    +Universal_Game_Configurator.Editor.EditDesc   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:Universal_Game_Configurator     5   	   QUniversal_Game_Configurator)clr-namespace:Universal_Game_Configurator     5   	   -   5          � Title$  Description Editor��5	   	   $	��472��6$   $	��540��61    � 
ResizeMode$ NoResize=�6=   &   System.Windows.Media.TextOptions   TextFormattingMode$ Display=�6S   .��5
      �  � ColumnDefinitions 5   
   �� 5      $	��53* �6   �� 5      $
��475* �6    � RowDefinitions 5   
   �� 5      $
��135* �6   �� 5      $	��30* �6   �� 5      $	��31* �6   �� 5      $	��31* �6   �� 5      $
��169* �6   �� 5      $	��68* �6   .+�5   
   �� -   5         ��Name$ listDesc��5      $��10q�6$   $��Visible=�60   $
��Auto=�6c   $��2��6�   $��Stretch=�6�   $��Stretch=�6�   ��5      �� 5      .R�5      �� ��6    �� *Tag+5      5      �� 5   
   -   5         ��Name$ txtId��5      $
��Left=�6!   $��23��6<   $��5,5,0,0q�6H   $��1��6Y    �� TextWrapping$
 Wrap=�6f   $	��Top=�6z   $	��455��6�   $��1��6�   $��Center=�6�   6�   �� 5   
   $	��ID:��6   $
��Left=�6   $��35��69   $��10,0,0,0q�6E   $��1��6W   $	��Top=�6d   $��43��6|   $��Right=�6�   $��Center=�6�   $��2��6�   �� 5    
   $
��Tag:��6   $
��Left=�6   $��33��6:   $��10,0,0,0q�6F   $��2��6X   $	��Top=�6e   $��43��6}   $��Right=�6�   $��Center=�6�   $��2��6�   �� 5!   
   -   5        $ txtTag��5!      $
��Left=�6"   $��23��6=   $��5,5,0,0q�6I   $��2��6Z   $
 Wrap=�6g   $	��Top=�6{   $	��455��6�   $��1��6�   $��Center=�6�   6�   �� 5"   
   $��Image:��6   $
��Left=�6!   $��33��6<   $��3��6H   $	��Top=�6U   $��53��6m   $��Right=�6x   $��Center=�6�   $��2��6�   �� 5#   
   -   5        $ txtImage��5#      $
��Left=�6$   $��23��6?   $��5,5,0,0q�6K   $��3��6\   $
 Wrap=�6i   $	��Top=�6}   $	��455��6�   $��1��6�   $��Center=�6�   6�   �� 5$   
   $��Text:��6   $
��Left=�6    $��27��6;   $��4��6G   $	��Top=�6T   $��53��6l   $��Right=�6w   $��Center=�6�   $��0,2,0,0q�6�   �� 5%   
   -   5        $ txtText��5%      $��4��6#   $��1��60   $��Stretch=�6@    �� 
AcceptsTab . 	 �� AcceptsReturn	 . $
 Wrap=�6�   $��Stretch=�6�   $��
5,10,10,10q�6�   6�   �� 5&   
   -   5        
 ��Name$
 btnDel��5&      $��2��6!   $	��DEL��65   $
��Left=�6C   $��45��6^   $��	10,10,0,0q�6j   $��5��6}   $	��Top=�6�   $��74��6�   6�   �� 5'   
   -   5        $
 btnNew��5'      $	��NEW��6!   $
��Left=�6/   $��45��6J   $��	36,10,0,0q�6V   $��5��6i   $	��Top=�6v   $��74��6�   $��1��6�   $
��Bold"�6�   6�   �� 5(   
   -	   5        $
 btnSave��5(      $��SAVE ALL��6"   $��1��65   $
��Left=�6E   $��
135,10,0,0q�6`   $��5��6t   $	��Top=�6�   $	��127��6�   $��45��6�   $
��Bold"�6�   6�   �� 5)   
   -
   5        $
 btnBack��5)      $��GO BACK��6"   $��1��64   $
��Left=�6D   $��
267,10,0,0q�6_   $��5��6s   $	��Top=�6�   $��95��6�   $��45��6�   6�   �� 5*   
   -   5        $
 btnRaw��5*      $��SHOW RAW��6!   $��1��64   $
��Left=�6D   $��
367,10,0,0q�6_   $��5��6s   $	��Top=�6�   $��93��6�   $��45��6�   6�   5,      5-      