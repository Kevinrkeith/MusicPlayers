   M S B A M L   `   `   `  ����G  CMusicPlayers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:MusicPlayers.ViewsMusicPlayers.Views  5   	   A%clr-namespace:MusicPlayers.ViewModelsMusicPlayers.ViewModels  5   	   %    MusicPlayers.Views.FileExplorer   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:MusicPlayers.Views     5   	   ;	viewmodel%clr-namespace:MusicPlayers.ViewModels     5   	     � Title$  FileExplorer��5	   	   $	��300��6   $	��600��6+    � DataContext 5
      3   -MusicPlayers.ViewModels.FileExplorerViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6;   $��1��6H   ��6   ��  �� Path$ Directories���5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6!   5      ��5      �� 5      .R�5      �� $ 
Horizontal=�6!   .+�5      �� ��5       �� 5!   "   .R�5"   &   �� ��60   �� 5#   #   5%      5&      5'      5)      �� 5*   
   $��	AAAAAAAAA��6   �� 5+   
   $��1��65   $��1��6B   ��6   �� $ Files���5,      �� 5-      .R�5.      �� $ 
Horizontal=�6!   .+�5/      �� ��50      �� 51   "   .R�52   &   �� ��60   �� 53   #   55      56      57      59      5:      5;      