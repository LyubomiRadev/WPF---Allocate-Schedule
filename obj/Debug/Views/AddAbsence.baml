   M S B A M L   `   `   `  ����D  @LogInForm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:LogInForm.ViewModelsLogInForm.ViewModels  5   	   3clr-namespace:LogInForm.ModelsLogInForm.Models  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	        LogInForm.Views.AddAbsence   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   T PCatel.Extensions.Controls, Version=4.5.4.0, Culture=neutral, PublicKeyToken=nullE ACatel.MVVM, Version=4.5.4.0, Culture=neutral, PublicKeyToken=null'catelhttp://catel.codeplex.com   5   	   0local"clr-namespace:LogInForm.ViewModels   5   	   -local2clr-namespace:LogInForm.Models   5   	   2sys&clr-namespace:System;assembly=mscorlib   5   	     � WindowStartupLocation$  CenterScreen=�5   	   $	��300��5	   	   $	��500��5
   	    � 
ResizeMode$ NoResize=�5   	    � 	Resources 5       �� 
TargetType �� Property �� Value��%  '��       �� 5   
   " ��6   .�5      ��  �@��TextAlignment$ Center=�5      �� 5       � ��$ 30(�5      �� 5       � �� �#4dd65f5      �� 5       � ��
 �   �5      �� 5       � ��$ 1q�5      5      5      .��5      � ���#009cad � RowDefinitions 5!   
   �� 5"      $	��140 �6   �� 5#      $	��140 �6   �� 5$      $	��140 �6   �� 5%      $��* �6   .+�5(   
   �� $��0��6   .+�5*      �� $��Name:��6   $
��Bold"�5+      $
��Left=�5,      $	��Top=�5-      �� 5/      ���#00c9db$	��130��51      $	��290��52      $��Center=�53      $��Center=�54      ��5/      �� *Name+54      56      �� 58   
   $��1��6   $��0,0,0,5q�59      .+�5;      �� $��Abriviature:��6   $
��Bold"�5<      $
��Left=�5=      $	��Top=�5>      �� 5@      ���#00c9db$	��130��5B      $	��290��5C      $��Center=�5D      $��Center=�5E      ��5@      �� *Abriviature+5E      5G      �� 5I   
   $��2��6   $��0,0,0,5q�5J      .+�5L      �� $��Days:��6   $
��Bold"�5M      $
��Left=�5N      $	��Top=�5O      �� 5Q      ���#00c9db$	��130��5S      $	��290��5T      $��Center=�5U      $��Center=�5V      ��5Q      �� *Days+5V      5X      �� 5Z   
   $��3��6   $	��Add��5[      $
��Bold"�5\         CreateUpdateBtn#��[  5]      ��5^      �� *AddAbsenceCommand+5_      5a      