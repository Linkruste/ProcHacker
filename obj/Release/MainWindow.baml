   M S B A M L   `   `   `  ���� E  AProcHacker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ProcHacker
ProcHacker      ProcHacker.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     *localclr-namespace:ProcHacker     -     � Title$  
MainWindow��$	��450��$	��800�� � AllowsTransparency . 
������  � WindowStyle$
 None=�.��� .+���  �� CornerRadius$ 10��$��3q�����  �� 
StartPoint$	 0,0&� �� EndPoint$	 1,1&�.���    BorderStop1 � Color# [   � Offset$ 0Q��   BorderStop2# [ $ 1Q�._��  � ColumnDefinitions �� �� $��5* �.+��� $��0��$ 	10,0,0,10������ $	 0,0&�$ 1,0.5&�.���   NavPanelStop1# [ $ 0Q��   NavPanelStop2# [ $ 1Q�._��� -   $��NavContainer��.+��� -   $��30��$��10, 30, 0, 40q�	 �� Orientation$	 
Horizontal=�.+��� $��/UI/Assets/CPU.png��$��30��$
��Left=��� $��
ProcHacker��$��Candara)�$��10,0,0,0q� 
 Title1#��[ $��Center=�$��16(��� $��1��$ 	0,10,10,0������ $	 1,0&�$ 1,0.5&�.���   ContentPanelStop1# [ $ 0Q��   ContentPanelStop2# [ $ 1Q�._�� 
 � RowDefinitions
 �� $��30 ��� �� $
�� 20* �.+�� -   $��
TabContent��$��2��.+�� -   $��
CPUContent��$��2��$y�	Collapsed=� �� �� 
 �� $��2* ��� �� $��2* ��� �� $��2* �� -   $��DevicesLibrary��$��2��$y�	Collapsed=� �� �� 
 �� $��2* ��� �� $��2* ��� �� $��2* �� -   $��SettingsContent��$��2��$y�Visible=� �� �� 
 �� $��2* ��� �� $��2* ��� �� $��2* �.+��� $��1��
������ $��0q�.@��� 