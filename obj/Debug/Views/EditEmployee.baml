   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      D @LogInForm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:LogInForm.ViewModelsLogInForm.ViewModels 5      3clr-namespace:LogInForm.ModelsLogInForm.Models 5      "   LogInForm.Views.EditEmployee   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      T PCatel.Extensions.Controls, Version=4.5.4.0, Culture=neutral, PublicKeyToken=nullE ACatel.MVVM, Version=4.5.4.0, Culture=neutral, PublicKeyToken=null'catelhttp://catel.codeplex.com   5      2sys&clr-namespace:System;assembly=mscorlib   5      0local"clr-namespace:LogInForm.ViewModels   5      -local2clr-namespace:LogInForm.Models   5        � 
ResizeMode$  NoResize=�5       � WindowStartupLocation$ CenterScreen=�5	      $	��300��5
      $	��300��5       � 	Resources 5       �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius	 �� Triggers
 P� Property P� Value �� 
TargetName   positionTypes S� 
MethodName S� 
ObjectType   System.Enum S� MethodParameters M� TypeName  statusTypes��%-  '��       '��     &	      &	 �    �� 5   
   " ��6   .�5      ��  �@��TextAlignment$ Center=�5      �� 5       � ��$ 30(�5      �� 5       � �� �#fc6c445      �� 5       � ��
 �   �5      �� 5       � ��$ 1q�5      5      �� 5   
   " ��6   .�5      ��  � ��$ Stretch=�5      �� 5        � ��
 �   �5!      �� 5"       � �� 5#      �� 5$      " ��6&   .R�5%      �� $	 Btn��5&   !   $ 4��5%   !   ���#DA542D
���   �$��2q�5)   !   ._�5*      �� $��Center=�6/   $��Center=�5+   /   5,      	 5-      P� 5.      
 �@J�IsMouseOver . . �50   "   �� $	 Btn��6)    � �� �#fc6c4452   )   �� 53   "    �@�Cursor$
 Hand��54   )   55      57      59      5:      S� 5<   
   $ 	GetValues��5=      "  5>       5?      M� 5@      $ local2:Position��6   5B      S� 5D   
   $ 	GetValues��5E      "  5F       5G      M� 5H      $ local2:Status��6   5J      5L      .��5N      � ���#DA542D � RowDefinitions 5P   
   �� 5Q      $��30 �6   �� 5R      $��33 �6   �� 5S      $��30 �6   �� 5T      $��* �6   �� 5U      $��30 �6   �� 5V      $��* �6   �� 5W      $��* �6   .+�5Z   
   �� $��Status��6   $��0��5[      $��50��5\      $
��Left=�5]      $
��Bold"�5^      $��35,0,0,0q�5_      �� 5a   
   $��Position��6   $��0��5b      $��50��5c      $��Center=�5d      $
��Bold"�5e      $��20,0,0,0q�5f      �� 5h   
   $	��Age��6   $��Right=�5i      $
��Bold"�5j      $��50��5k      �� 5n   
    �� Orientation$ 
Horizontal=�6   $��1��5o      .+�5q      ��  �� SelectedIndex$ 0��5r      $��30��5t      $	��100��5u      $��Stretch=�5v      $	��Top=�5w      ��5q      ��  �� Source# [  �� SelectedItem 5s      �� *SelectedStatysType+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=���5x      �� 5z      .R�5{      ��  �� Padding$ 5q�6!   $��90��5|   !   $��30��5}   !   $��Stretch=�5~   !   ._�5      ��  �� TextAlignment$ Center=�6(   ��5�   (   �� 5�      5�      5�      �� 5�      $ 0��5�      $��30��5�      $	��100��5�      $��Stretch=�5�      $	��Top=�5�      ��5�      �� # [   5�      �� *SelectedPositionType+$ PropertyChanged=�$ TwoWay=���5�      �� 5�      .R�5�      �� $ 5q�6!   $��90��5�   !   $��30��5�   !   $��Stretch=�5�   !   ._�5�      �� $ Center=�6(   ��5�   (   �� 5�      5�      5�      �� 5�      $��30��5�      $��90��5�      $��Stretch=�5�      $��Bottom=�5�      $��0,0,0,3q�5�      ��5�      �� *	ChosenAge+ 5�      �� *SelectedAge+��5�      �� 5�      .R�5�      �� $ 5q�6!   $��27��5�   !   $��30��5�   !   $��Stretch=�5�   !   ._�5�      �� $ Center=�6(   ��5�   (   �� 5�      5�      5�      5�      �� 5�   
   $��2��6   $��First Name:��5�      $
��Bold"�5�      �� 5�   
   $��3��5�      ��5�      �� *	FirstName+5�      �� 5�   
   $��4��6   $��
Last Name:��5�      $
��Bold"�5�      �� 5�   
   $��5��5�      ��5�      �� *
LastName+5�      �� 5�   
   $��6��6   $��Update��5�      $
��Bold"�5�      ��5�      �� *EditEmployee+5�      5�      