   M S B A M L   `   `   `  ����H  DKolomyyaTrees, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:KolomyyaTreesKolomyyaTrees  5   	       KolomyyaTrees.TreesList   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:KolomyyaTrees     5   	     � Title$  	TreesList��5   	   $
��1080��6   $
��1920��6)   
������� � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      � ��5   
   �� 5       �� ImageSource$! img/background2blurMore.png��6   6E    � RowDefinitions 5   
   �� 5      $
��110* �6   �� 5      $
��970* �6   .+�5   
   � $��0��6   ���	#FF7A9E4A.+�5      �� -   5         ��Name$ 
homeButton��5      $��50,28,1807,28q�6@   ��6)   Z� ��6W   Z� .��5      �� $��img/home.png��6   $��48��6.    � Cursor$
 Hand��6:   5      �� 5      -   5        $ 
exitButton��5      $��1807,28,50,28q�6@   ��6)   Z� ��6W   Z� .��5      �� $��img/exit.png��6   $��40��6.   $
 Hand��6:   5      �� 5      -   5        $ TreesListButton��5      $)��#Переглянути список��6.   
�������$��PT Sans)�6t   $��32(�6�   $��150,28,1449,28q�6�   $
 Hand��6�   ��6K   Z� ��6�   Z� 6�   �� 5      -   5        $ TreeAddButton��5      $��Додати дерево��6,   
�������$��PT Sans)�6m   $��32(�6�   $��494,28,1174,28q�6�   $
 Hand��6�   ��6D   Z� ��6�   Z� 6�   �� 5      -   5        $ TreesMapButton��5      $0��*Переглянути мапу міста��6-   
�������$��PT Sans)�6w   $��32(�6�   $��758,28,773,28q�6�   $
 Hand��6�   ��6N   Z� ��6�   Z� 6�   �� 5      -   5        $ 
TreeSearch��5      $��Пошук дерева��6)   
�������$��PT Sans)�6i   $��32(�6~   $��1164,28,519,28q�6�   $
 Hand��6�   ��6@   Z� ��6�   Z� 6�   5      � 5!   
   $��1��6   .+�5"      �� -   5         ��Name$ labelTreesKPD��5"      $H��BДо нашої бази даних занесено Н дерев��6+   $
��Left=�6Z   $��541,852,0,0q�6u   $	��Top=�6�   $��40(�6�   
�������
���   �$��PT Sans)�6�   &   System.Windows.Controls.DataGrid  5#      -   5          Name$
 grid��5#      $
��Left=�6%   $	��771��6@   $��
956,56,0,0q�6M   $	��Top=�6a   $	��763��6y   6�   �� 5$      $��Номер дерева��6   $
��Left=�6+   $	��Top=�6F   $��
130,67,0,0q�6^   $��50��6r   $	��171��6~   $��24(�6�   $��PT Sans)�6�   
�������6�   �� 5%      $��Вік дерева��6   $
��Left=�6)   $	��Top=�6D   $��130,165,0,0q�6\   $��51��6q   $	��135��6}   $��24(�6�   $��PT Sans)�6�   
�������6�   �� 5&      $��Стан дерева��6   $
��Left=�6*   $	��Top=�6E   $��130,268,0,0q�6]   $��50��6r   $	��145��6~   $��24(�6�   $��PT Sans)�6�   
�������6�   �� 5'      $��Порода дерева��6   $
��Left=�6,   $	��Top=�6G   $��130,366,0,0q�6_   $��50��6t   $	��186��6�   $��24(�6�   $��PT Sans)�6�   
�������6�   �� 5(      $��Плоди дерева��6   $
��Left=�6+   $	��Top=�6F   $��130,461,0,0q�6^   $��50��6s   $	��171��6   $��24(�6�   $��PT Sans)�6�   
�������6�   �� 5)      $��Координати��6   $
��Left=�6)   $	��Top=�6D   $��130,570,0,0q�6\   $��51��6q   $	��153��6}   $��24(�6�   $��PT Sans)�6�   
�������6�   �� 5*      $-��'Додаткова інформація��6   $
��Left=�63   $	��Top=�6N   $��130,678,0,0q�6f   $��51��6{   $	��271��6�   $��24(�6�   $��PT Sans)�6�   
�������6�   �� 5+      -	   5         ��Name$ TreeIdTB��5+      $
��Left=�6(   $��44��6C   	 �� TextWrapping$
	 Wrap=�6O   $	��Top=�6c   $	��432��6{   $��
415,73,0,0q�6�   $��24(�6�   $��PT Sans)�6�   �� 5,      -
   5        $ 	TreeVikTB��5,      $
��Left=�6)   $��44��6D   $
	 Wrap=�6P   $	��Top=�6d   $	��432��6|   $��415,173,0,0q�6�   $��24(�6�   $��PT Sans)�6�   �� 5-      -   5        $ 
TreeStanTB��5-      $
��Left=�6*   $��45��6E   $
	 Wrap=�6Q   $	��Top=�6e   $	��432��6}   $��415,275,0,0q�6�   $��24(�6�   $��PT Sans)�6�   �� 5.      -   5        $ TreePorodaTB��5.      $
��Left=�6,   $��44��6G   $
	 Wrap=�6S   $	��Top=�6g   $	��432��6   $��415,374,0,0q�6�   $��24(�6�   $��PT Sans)�6�   �� 5/      -   5        $ TreePloduTB��5/      $
��Left=�6+   $��45��6F   $
	 Wrap=�6R   $	��Top=�6f   $	��432��6~   $��415,468,0,0q�6�   $��24(�6�   $��PT Sans)�6�   �� 50      -   5        $ TreePositionNTB��50      $
��Left=�6/   $��45��6J   $
	 Wrap=�6V   $	��Top=�6j   $	��209��6�   $��415,570,0,0q�6�   $��24(�6�   $��PT Sans)�6�   �� 51      -   5        $ TreePositionETB��51      $
��Left=�6/   $��45��6J   $
	 Wrap=�6V   $	��Top=�6j   $	��213��6�   $��634,570,0,0q�6�   $��24(�6�   $��PT Sans)�6�   �� 52      -   5        $ 
TreeInfoTB��52      $
��Left=�6*   $��45��6E   $
	 Wrap=�6Q   $	��Top=�6e   $	��432��6}   $��415,678,0,0q�6�   $��24(�6�   $��PT Sans)�6�   �� 53      -   5        $ TreeUpdateBnt��53      $��Обновити��6,   $
��Left=�6?   $	��Top=�6Z   $	��304��6r   $��136,788,0,0q�6~   $��39��6�   $��24(�6�   $��PT Sans)�6�   ���	#FF7B9F4B
�������6�   �� 54      -   5        $ TreeRemoveBnt��54      $��Видалити��6,   $
��Left=�6?   $	��Top=�6Z   $	��306��6r   $��541,788,0,0q�6~   $��39��6�   $��24(�6�   $��PT Sans)�6�   ���	#FF7B9F4B
�������6�   55      58      59      