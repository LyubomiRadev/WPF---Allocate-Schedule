   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      D @LogInForm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:LogInForm.ViewModelsLogInForm.ViewModels 5      3clr-namespace:LogInForm.ModelsLogInForm.Models 5      !   LogInForm.Views.AddEmployee   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      T PCatel.Extensions.Controls, Version=4.5.4.0, Culture=neutral, PublicKeyToken=nullE ACatel.MVVM, Version=4.5.4.0, Culture=neutral, PublicKeyToken=null'catelhttp://catel.codeplex.com   5      2sys&clr-namespace:System;assembly=mscorlib   5      0local"clr-namespace:LogInForm.ViewModels   5      -local2clr-namespace:LogInForm.Models   5        � 
ResizeMode$  NoResize=�5       � WindowStartupLocation$ CenterScreen=�5	      $	��300��5
      $	��300��5       � 	Resources 5       �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius	 �� Triggers
 P� Property P� Value �� 
TargetName   positionTypes S� 
MethodName S� 
ObjectType   System.Enum S� MethodParameters M� TypeName  statusTypes��%1  '��       '��     &	  #    &	 �    �� 5   
   " ��6   .�5      ��  �@��TextAlignment$ Center=�5      �� 5       � ��$ 30(�5      �� 5       � �� �#fc6c445      �� 5       � ��
 �   �5      �� 5       � ��$ 1q�5      5      �� 5   
   " ��5      .�5      ��  � ��$ Stretch=�5       �� 5!       � ��
 �   �5"      �� 5#       � �� 5$      �� 5%      " ��6&   .R�5&      �� $	 Btn��5'   !   $ 4��5&   !   ���#DA542D
���   �$��2q�5*   !   ._�5+      �� $��Center=�6/   $��Center=�5,   /   5-      	 5.      P� 5/      
 �@J�IsMouseOver . . �51   "   �� $	 Btn��6)    � �� �#fc6c4453   )   �� 54   "    �@�Cursor$
 Hand��55   )   56      58      5:      5;      S� 5=   
   $ 	GetValues��5>      "  5?       5@      M� 5A      $ local2:Position��6   5C      S� 5E   
   $ 	GetValues��5F      "  5G       5H      M� 5I      $ local2:Status��6   5K      5M      .��5O      � ���#DA542D � RowDefinitions 5Q   
   �� 5R      $��30 �6   �� 5S      $��33 �6   �� 5T      $��30 �6   �� 5U      $��* �6   �� 5V      $��30 �6   �� 5W      $��* �6   �� 5X      $��* �6   .+�5[   
   �� $��Status��6   $��0��5\      $��50��5]      $
��Left=�5^      $
��Bold"�5_      $��35,0,0,0q�5`      �� 5b   
   $��Position��6   $��0��5c      $��50��5d      $��Center=�5e      $
��Bold"�5f      $��20,0,0,0q�5g      �� 5i   
   $	��Age��6   $��Right=�5j      $
��Bold"�5k      $��50��5l      �� 5p   
    �� Orientation$ 
Horizontal=�6   $��1��5q      .+�5s      ��  �� SelectedIndex$ 0��5u      $��30��5w      $	��100��5x      $��Stretch=�5y      $	��Top=�5z      ��5t      ��  �� Source# [  �� SelectedItem 5v      �� *SelectedStatysType+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=���5{      �� 5}      .R�5~      ��  �� Padding$ 5q�6!   $��90��5   !   $��30��5�   !   $��Stretch=�5�   !   ._�5�      ��  �� TextAlignment$ Center=�6(   ��5�   (   �� 5�      5�      5�      �� 5�      $ 0��5�      $��30��5�      $	��100��5�      $��Stretch=�5�      $	��Top=�5�      ��5�      �� # [   5�      �� *SelectedPositionType+$ PropertyChanged=�$ TwoWay=���5�      �� 5�      .R�5�      �� $ 5q�6!   $��90��5�   !   $��30��5�   !   $��Stretch=�5�   !   ._�5�      �� $ Center=�6(   ��5�   (   �� 5�      5�      5�      �� 5�      $��30��5�      $��90��5�      $ 0��5�      $��Stretch=�5�      $	��Top=�5�      ��5�      �� *	ChosenAge+ 5�      �� *SelectedAge+��5�      �� 5�      .R�5�      �� $ 5q�6!   $��27��5�   !   $��30��5�   !   $��Stretch=�5�   !   ._�5�      �� $ Center=�6(   ��5�   (   �� 5�      5�      5�      5�      �� 5�   
   $��2��6   $��First Name:��5�      $
��Bold"�5�      �� 5�   
   $��3��5�      ��5�      �� *	FirstName+5�      �� 5�   
   $��4��6   $��
Last Name:��5�      $
��Bold"�5�      �� 5�   
   $��5��5�      ��5�      �� *
LastName+5�      �� 5�   
   $��6��6   $	��Add��5�      $
��Bold"�5�      ��5�      �� *AddEmployeeCommand+5�      5�      