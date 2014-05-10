﻿Збор!
============
<h4> Почетен изглед </h4>
<img src = "http://imgur.com/M2Vogko.png" alt ="First look" />
---
<h4> Запознавање </h4>
---
<p>Инспирацијата за имплементирање на оваа игра со зборови е добиена од квизот на МТВ1 наречен „Круг на знаење“. При самото стартување на играта, може да се забележи дека таа, од една страна, не зазема голем визуелен простор, но од друга страна, е прилично функционална 2D игра за рекреација. 
<br />
<br />
Играта е базирана на веќе постоечка игра именувана како <a href ="https://github.com/ThresherMaw/Zbor_Game_VP/blob/master/Zbor/Originalna%20igra/Lingo/Lingo.cs">Lingo</a>, која е, се разбира, вклучена е во самиот проект, но таа, за разлика од Збор!, има попримитивен изглед и е без сите дополнителни функционалности вклучени во нејзиниот наследник.
<br />
<br />
Целосниот код е поделен во региони, со цел полесна навигација низ истиот. Воедно, поголемиот дел од кодот е проследен со коментари, со цел да се објасни намерата на линиите код по коментарот. Притоа, вклучени се три форми:<b> самиот интерфејс на играта, листата на рекорди и кратко упатство</b>.
<br />
<br />
Начинот на играње на оваа игра е доста едноставен. Крајната цел на оваа игра е да се погоди случајно генерираниот збор со 5 букви од самата игра.
</p>
<h4> Упатство </h4>
---
<ul>
<li>Откако ќе се стартува играта, потребно е од страна на корисникот (играчот) да притисне ЕНТЕР (како што е прикажано на првата слика) за да се започне со играње. </li>
<li>Во играта има вградено бројач кој го претставува бонусот поени што се добиваат при еден погоден збор. Па така, по притискањето, овој бројач започнува да се намалува од 1000 (поени) па се до нула. </li>
<li>На десен клик се прикажува мени со три опции, при што може да се одбери тежина на генерираните зборови (нивоа: лесно/средно/тешко), кратко упатство за начинот на играње, како и опција за излез од играта. </li>
<li>Играта располага со преку 2000 исклучиво македонски зборови (именки/придавки) кои припаѓаат на едно од претходно наведените нивоа на тежина.</li>
<li>На почетокот се прикажуваат две букви кои се составен дел од зборот.Тие, исто како целиот збор, се случајно генерирани букви. Со доближување на курсорот до прикажаните букви се добива коментар дека тие се наоѓаат на точна позиција во зборот при што по внесувањето се обојуваат со светло сина боја. Од друга страна, доколку одредени букви кои играчот ги внесил, ги содржи генерираниот збор, но не се наоѓаат на правилната позиција, повторно се добива коментар, но со спротивната порака и се обојуваат со кафеава боја. Тоа можеме да го забележиме од наредната слика. </li>
</ul>
<img src="http://imgur.com/zNFnXe5.png" alt ="Correct position"/>
<h4> Правила </h4>
---
<p>Правилата на играње се следните: <br/></p>
<ol>
<li>Играчот има максимум 5 обиди за да го погоди дадениот збор.</li>
<li>Полето за текст прифаќа САМО кирилични букви.</li>
</ol>
