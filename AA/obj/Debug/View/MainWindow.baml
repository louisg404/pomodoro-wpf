   M S B A M L   `   `   `  ����=  9AA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:pomodoropomodoro  5   	       pomodoro.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:pomodoro     5   	     � Title$  Accueil��5   	   $	��500��6   $	��400��6&   .��5	      � .+�5
   
   ��  �� Orientation$ 
Horizontal=�6   $	��Top=�6.   .+�5      o� .@�5      m� -   5        $��Se déconnecter��5      $	��400��63   6?   5      5       � 5   
   -   5          �Name$
 Main��5      $��0,40,0,0q�6     � NavigationUIVisibility$ Hidden=�60   �� 5   
   -   5         ��Name$ Timer��5      $��40(�6   $��
10,50,10,0q�6-   $	��Top=�6A   $	��110��6Y   $	��198��6f   �� 5   
   -   5         ��Name$ 
TravailSum��5      $	��25'��6(   $��
10,50,10,0q�63   $	��Top=�6G   $��50(�6_   �� 5   
   -   5        $ TextTravail��5      $��Temps de travail��6)   $
��Left=�6A   $��
10,145,0,0q�6\   $	��Top=�6p   �� 5   
   -   5         ��Name$ Start��5      $��	Démarrer��6    $
��Left=�63   $��
10,170,0,0q�6N   $	��Top=�6b   $��5q�6z   
���2�2�
���2�2�
���   �6�   �� 5   
   -   5        $ Pause��5      $��Pause��6    $��Right=�60   $��
0,170,10,0q�6L   $	��Top=�6`   $��5q�6x   
�������
�������6�   �� 5   
   -   5        $ 	TextPause��5      $��Temps de pause��6'   $
��Left=�6=   $��
10,145,0,0q�6X   $	��Top=�6l   �� 5   
   -	   5        $ Start2��5      $��	Démarrer��6!   $
��Left=�64   $��
10,170,0,0q�6O   $	��Top=�6c   $��5q�6{   
���2�2�
���2�2�
���   �6�   �� 5   
   -
   5        $ Pause2��5      $��Pause��6!   $��Right=�61   $��
0,170,10,0q�6M   $	��Top=�6a   $��5q�6y   
�������
�������6�   �� 5    
   -   5        $ Liste��5       $��Historique :��6#   $
��Left=�67   $��
10,220,0,0q�6R   $	��Top=�6f   �� 5"   
   -   5        $ Compteur��5"      $�� ��6&   $��
10,250,0,0q�6.   $	��Top=�6B   �� 5%   
   -   5        $
 Info��5%      $0��*Terminer un cycle complet pour sauvegarder��6"   $
��Left=�6T   $��	10,0,0,10q�6o   $��Bottom=�6�   �� 5&   
   -   5        $
 Save��5&      $��Sauvegarder��6   $
��Left=�65   $��	10,0,0,10q�6P   $��Bottom=�6c   $��5q�6~   
������
�������6�   5'      5(      