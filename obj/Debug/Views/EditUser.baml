   M S B A M L   `   `   `  ����D  @LogInForm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:LogInForm.ViewModelsLogInForm.ViewModels  5      3clr-namespace:LogInForm.ModelsLogInForm.Models  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5          LogInForm.Views.EditUser   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      T PCatel.Extensions.Controls, Version=4.5.4.0, Culture=neutral, PublicKeyToken=nullE ACatel.MVVM, Version=4.5.4.0, Culture=neutral, PublicKeyToken=null'catelhttp://catel.codeplex.com   5      0local"clr-namespace:LogInForm.ViewModels   5      -local2clr-namespace:LogInForm.Models   5      2sys&clr-namespace:System;assembly=mscorlib   5        � WindowStartupLocation$  CenterScreen=�5      $	��300��5	      $	��700��5
       � 
ResizeMode$ NoResize=�5       � 	Resources 5       �� 
TargetType �� Property �� Value   accessTypes S� 
MethodName S� 
ObjectType  System.Enum S� MethodParameters	 M� TypeName��%�  '��       &	      �� 5   
   " ��6   .�5      ��  �@��TextAlignment$ Center=�5      �� 5       � ��$ 30(�5      �� 5       � �� �#4dd65f5      �� 5       � ��
 �   �5      �� 5       � ��$ 1q�5      5      S� 5   
   $ 	GetValues��5      "  5       5      M� 5      $	 local2:AccessType��6   5!      5#      .��5%      � ���#00af1a
 � RowDefinitions
 5'   
   �� 5(      $��30 �6   �� 5)      $��20 �6   �� 5*      $��* �6   �� 5+      $��20 �6   �� 5,      $��* �6   �� 5-      $��20 �6   �� 5.      $��* �6   �� 5/      $��20 �6   �� 50      $��* �6   �� 52      $��50 �6   .+�56   
   �� $��0��6   $��Access Type:��57      $
��Bold"�58      $��70��59      $
��Left=�5:      �� 5<   
   $��0��6    �� SelectedIndex$ 0��5>      $��30��5@      $	��200��5A      $��Right=�5B      $	��Top=�5C      ��5=      ��  �� Source# [   �� SelectedItem 5?      �� *SelectedAccessType+��5D      �� 5F      .R�5G      ��  �� Padding$ 5q�6   $	��190��5H      $��30��5I      $��Stretch=�5J      ._�5K      ��  �� TextAlignment$ Center=�6$   ��5L   $   �� 5M      5N      5Q      �� 5S   
   $��1��6   $��First Name:��5T      $
��Bold"�5U      �� 5V   
   $��2��5W      ��5V      �� *	FirstName+5W      �� 5Y   
   $��3��6   $��
Last Name:��5Z      $
��Bold"�5[      �� 5\   
   $��4��5]      ��5\      �� *
LastName+.��5]       � ToolTip 5^      �� 5_      .+�5`      �� $"��Възможни опции:��6    $
��Bold"�5a       �� 5b      $!��Плод / Зеленчук��6    5c      .��5d      5e      �� 5g   
   $��5��6   $��
User Name:��5h      $
��Bold"�5i      �� 5j   
   $��6��5k      ��5j      �� *
UserName+5k      �� 5m   
   $��7��6   $��	Password:��5n      $
��Bold"�5o      �� 5p   
   $��8��5q      ��5p      �� *
Password+5q      �� 5s   
   $��Update��6   $
��Bold"�5t      $��9��5u        CreateUpdateBtn#��[ 5w      ��5v      �� *
UpdateUser+5w      5x      5y      