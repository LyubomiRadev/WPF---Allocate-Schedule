   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      D @LogInForm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:LogInForm.ViewModelsLogInForm.ViewModels 5      3clr-namespace:LogInForm.ModelsLogInForm.Models 5          LogInForm.Views.CreateUser   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      T PCatel.Extensions.Controls, Version=4.5.4.0, Culture=neutral, PublicKeyToken=nullE ACatel.MVVM, Version=4.5.4.0, Culture=neutral, PublicKeyToken=null'catelhttp://catel.codeplex.com   5      2sys&clr-namespace:System;assembly=mscorlib   5      0local"clr-namespace:LogInForm.ViewModels   5      -local2clr-namespace:LogInForm.Models   5        � 
ResizeMode$  NoResize=�5       � WindowStartupLocation$ CenterScreen=�5	      $	��300��5
      $	��700��5       � 	Resources 5       �� 
TargetType �� Property �� Value   accessTypes S� 
MethodName S� 
ObjectType   System.Enum S� MethodParameters	 M� TypeName��%�  '��       &	      �� 5   
   " ��6   .�5      ��  �@��TextAlignment$ Center=�5      �� 5       � ��$ 30(�5      �� 5       � �� �#4dd65f5      �� 5       � ��
 �   �5      �� 5       � ��$ 1q�5      5      S� 5   
   $ 	GetValues��5      "  5       5      M� 5       $	 local2:AccessType��6   5"      5$      .��5&      � ���#00af1a
 � RowDefinitions
 5(   
   �� 5)      $��30 �6   �� 5*      $��20 �6   �� 5+      $��* �6   �� 5,      $��20 �6   �� 5-      $��* �6   �� 5.      $��20 �6   �� 5/      $��* �6   �� 50      $��20 �6   �� 51      $��* �6   �� 53      $��50 �6   .+�57   
   �� $��0��6   $��Access Type:��58      $
��Bold"�59      $��70��5:      $
��Left=�5;      �� 5=   
   $��0��6    �� SelectedIndex$ 0��5?      $��30��5A      $	��200��5B      $��Right=�5C      $	��Top=�5D      ��5>      ��  �� Source# [   �� SelectedItem 5@      �� *SelectedAccessType+��5E      �� 5G      .R�5H      ��  �� Padding$ 5q�6   $	��190��5I      $��30��5J      $��Stretch=�5K      ._�5L      ��  �� TextAlignment$ Center=�6$   ��5M   $   �� 5N      5O      5R      �� 5T   
   $��1��6   $��First Name:��5U      $
��Bold"�5V      �� 5W   
   $��2��5X      ��5W      �� *	FirstName+5X      �� 5Z   
   $��3��6   $��
Last Name:��5[      $
��Bold"�5\      �� 5]   
   $��4��5^      ��5]      �� *
LastName+.��5^      5_      �� 5a   
   $��5��6   $��
User Name:��5b      $
��Bold"�5c      �� 5d   
   $��6��5e      ��5d      �� *
UserName+5e      �� 5g   
   $��7��6   $��	Password:��5h      $
��Bold"�5i      �� 5j   
   $��8��5k      ��5j      �� *
Password+5k      �� 5m   
   $	��Add��6   $
��Bold"�5n      $��9��5o        CreateUpdateBtn#��[ 5q      ��5p      �� *CreateNewUser+5q      5r      5t      