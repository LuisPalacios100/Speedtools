   M S B A M L   `   `   `  ���� E  ASpeedtools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Speedtools
Speedtools      Speedtools.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     *localclr-namespace:Speedtools       � Title$  
Speedtools��$	��425��$	��355�� � 
ResizeMode$ CanMinimize=�.��� $��0,0,0,0q�.+��� -    ��Name$ 
tabControl��$��Center=�$	��385��$	��Top=�$	��332��.@��� $��Text Manipulator��$	��110��.��� 
�������.+��� -    ��Name$ txtTextManipulatorInOut��$
��Left=�$	��200��$��	10,10,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��306��" �� VerticalScrollBarVisibility$
 Auto=� �� AcceptsReturn$
 True���� -    ��Name$ btnClearTextManipulator��$��Clear��$
��Left=�$	��Top=�$��40��$��274,188,0,0q��� $��Center=�$	��109��$��	0,215,0,0q�$	��Top=�$	��304��.@��� $��Convert��$��60��.��� .+��� -    ��Name$ cmbPreDelim��$
��Left=�$��24��$��10,0,0,0q�$��Center=�$��85��	 �� SelectedIndex$	 0��.@��� $��Column���� $��Comma���� $��	Semicolon���� -   $ btnListConvert��$��Convert��$��208,25,15,26q��� -   $ cmbPostDelim��$
��Left=�$��24��$��Center=�$��85��$	 1��$��	116,0,0,0q�.@��� $��Column���� $��Comma���� $��	Semicolon���� $��>��$��96,26,182,31q��� -   $ btnFlip��$
��Flip��$��94,58,181,7q�$��9(��� $��Blanks��$��60��.��� .+��� -   $ btnNukeBlanks��$��Nuke Blanks��$��38,25,154,25q��� -	   $ btnTrimBlanks��$��Trim Blanks��$��154,25,38,25q��� $��Attacher��$��60��.��� .+��� -
   $ txtAttacher��$
 Wrap=�$��99,31,99,31q��� -   $ 
btnPrepend��$��Prepend��$��10,28,206,28q��� -   $ 	btnAppend��$��Append��$��206,28,10,28q��� $��Replacer��$��60��.��� .+��� -   $ txtPreReplace��$
 Wrap=�$��16,38,212,21q��� -   $ txtPostReplace��$
 Wrap=�$��111,38,117,21q��� $��Replace��$��24,14,220,40q��� $
��With��$��127,14,134,39q��� $��>��$��90,35,191,18q��� -   $ 
btnReplace��$��Replace��$��199,28,17,20q��� $��Makeup��$��60��.��� .+��� -   $ btnRemoveDuplicates��$��Remove Duplicates��$��17,6,152,42q��� -   $ btnAlphabeticalOrder��$��Alphabetical Order��$��152,6,17,42q��� -   $ btnLower��$��All Lowercase��$��17,44,152,5q��� -   $ btnUpper��$��All Uppercase��$��152,44,17,5q��� -   $ btnUndoTextManipulator��$
��Undo��$
��Left=�$	��Top=�$��40��$��
12,188,0,0q��� -   $ btnRedoTextManipulator��$
��Redo��$
��Left=�$	��Top=�$��40��$��
54,188,0,0q��� $��Link Opener��$	��109��.��� 
�������.+��� -   $ txtLinkOpener��$��2��$
��Left=�$	��200��$��	10,10,0,0q�$
 Wrap=�$	��Top=�$	��306��$
 True��$
 Auto=��� -   
 ��Name$
 lbLinks��$��38,215,38,75q�$ �� IsSynchronizedWithCurrentItem$
 TrueY����� ���� .R�	�  	�Name$ rdiLinksDynamic��-   ���� *	content+ d� 	IsChecked ��  �� Path$ 
IsSelected� �� RelativeSource ��  �� AncestorType" ��
 � Tag �� *tag+�� -   $ btnOpenLinks��$��Open in Browser��$
��Left=�$��33��$��
91,287,0,0q�$	��Top=�$	��150���� -   $ btnClearLinkOpener��$��Clear��$
��Left=�$	��Top=�$��40��$��274,188,0,0q��� -   $ btnLinkSettings��$��Settings��$
��Left=�$%��18                             ��$��280,310,0,0q�$	��Top=�$��40��$��10(��� $��Blurbs��$	��109��.���� $
��Left=�$	��326��$
��Auto=�$��Center=�.��� 
�������$
��Auto=�.+��� -    ��Name$ icBlurbs��$��	0,45,0,25q����� .R��� $ btnBlurbDynamic��-   $	��250��$��40��$��2,2,2,2q�$��14(�$��Normal"����� *	content+�� -    ��Name$ 	lblBlurbs��$�� ��$��Right=�$	��Top=�$��	54,6,10,0q�$	��262��$��Right=�$��15(�$
��Bold"��� -   $ btnBlurbBack��$
��Back��$
��Left=�$��21��$��5,10,0,0q�$	��Top=�$��49���� $��Center=�$��26��$��Bottom=�$	��340��$��2,0,2,2q�.@��� -    $ lblStatusBar��$�� ��$��20��$	��312��$
��Left=�$��Bottom=�$��8,1,0,0q�$
��True���� -!    ��Name$ chkOnTop��$�� ��$��Right=�$��0,0,3,7q�$��Bottom=� � ToolTip$7 1Check to make Speedbar stay on top of all windows��