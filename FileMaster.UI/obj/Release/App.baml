   M S B A M L   `   `   `  ����   FileMaster.UI    FileMaster.UI.App   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Ld1p1;http://schemas.openxmlformats.org/markup-compatibility/2006       �� 	Resources   �� 
TargetType   MyWindow �� Property �� Value �� 
TargetType �� CornerRadius � ColumnDefinitions � RowDefinitions?  9System.Windows.Controls.Primitives.SelectiveScrollingGrid$   SelectiveScrollingOrientation  
MySettings	 �� UpdateSourceTrigger
 �� Orientation��%g  &	        &	     �� " �.���  �@�AllowsTransparency . ��  �@�WindowStyle$
 None=���  �@�
ResizeMode$ CanResizeWithGrip=���  � �� �� " �.R��� 
���   �$��3q�$ 1��#��z��#��z��
�������._�]� .+��� $��Stretch=�$��Stretch=�
�������$ 	0,0,10,10��._��  �� �� $��20 � �� $��* ��� $��20 �.+�� $��0��$��2�� �� $
��Auto ��� $��* ��� $��10 � �� $��0.65* ��� $��0.35* �.+��� $��
15,15,0,15q�$��0��$��2��$��0��$��Images/filemasterlogo.png��$	��500��$
��Left=��� $��15,0,0,0q�
���/���$��20(�
���   �$��1��$��0��
������ $
 Both=����� *	LogRows+���� .R�$� $��Bottom=��� $��	20,0,20,0q�$��1��$��1��.+��� $��50��$��32(����� *StartMonitoringCommand+���� *MonitorText+�� $��0,5,0,0q�$��50��$��32(�$��Settings������ *SettingsCommand+�� $��0,5,0,0q�$��50��$��32(�$��Exit application������ *ExitCommand+�� $��10��$��10��$��1��$��Bottom=�$��1���� " �.���  �@�AllowsTransparency . ��  �@�WindowStyle$
 None=���  �@�
ResizeMode$ CanResizeWithGrip=���  � ��$	 500����  � ��$	 800����  � �� �� " �.R��� 
���   �$��3q�$ 1��#��z��#��z��
�������._�]� .+��� $��Stretch=�$��Stretch=�
�������$ 	0,0,10,10��._��  �� �� $��20 � �� $
��Auto ��� $��* ��� $	��100 �.+��� $��
15,15,0,15q�$��0��$��2��$��0��$��Images/settingslogo.png��$	��300��$
��Left=��� $��0��$��1��$��20,0,0,0q�.+��� $��Destination folder���� ���� *DestinationFolder+$	 PropertyChanged=��� $��Torrentfile folder���� ���� *TorrentFileFolder+$	 PropertyChanged=��� $��Working folder���� ���� *WorkingFolder+$	 PropertyChanged=��� $��20,20,20,20q�$��0��$��2��$��2��$��Right=�$
 
Horizontal=�.+��� $��40��$��80��$
��Save������ *SaveCommand+�� $��40��$��80��$��10,0,0,0q�$��Cancel������ *CancelCommand+�� $��10��$��10��$��1��$��Bottom=�$��2��