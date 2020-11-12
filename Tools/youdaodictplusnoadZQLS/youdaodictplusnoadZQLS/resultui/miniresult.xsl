<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:include href="commonfile.xsl"/>

<xsl:template match="/">

<html>
<head>
<title>Local MiniQuery Result</title>

<!-- <link href="css/default.css" rel="stylesheet" type="text/css"/> -->
<!-- <link href="css/new.css" rel="stylesheet" type="text/css"/> -->
<!-- <script language="javascript" src="js/default.js"></script> -->

<!--<link href="css/mini.css" rel="stylesheet" type="text/css"/>-->
<script language="javascript" src="js/default.js"></script>

</head>

<body>

<div id="miniResult">

	<!--typo start-->
	<xsl:if test="not(/yodaodict/basic/dict)">
		<xsl:if test="not(/yodaodict/basic/simple-dict)">
			<xsl:if test="yodaodict/typos">
				<xsl:if test="not(/yodaodict/typos/typo/hh)">
					<br/>
					<div class="error-typo wrap">
					<h3>您是不是要找: </h3>
						<xsl:for-each select="yodaodict/typos/typo">
							<dl>
								<p class="typo-rel">
									<dt>
									<xsl:element name="a">
										<xsl:attribute name="class">title</xsl:attribute>
										<xsl:attribute name="style">text-decoration:none</xsl:attribute>
										<xsl:attribute name="href">
										app:ds:<xsl:value-of select="./word" />
										</xsl:attribute>

										<xsl:attribute name="onclick">
										ctlog(this, '<xsl:call-template name="standard_return_phrase" />' , 0, 'deskdict.mini.noresult.typo' , 1, 'CLICK',  '点击typo');
										</xsl:attribute>
															
										<xsl:attribute name="target">_self</xsl:attribute>  
										<xsl:value-of select="./word" />
									</xsl:element>
									</dt>
									<dd>
										<xsl:if test="./trans[text() != '']">
											：<xsl:value-of select="./trans" />
										</xsl:if>
										<xsl:if test="./trans[text() = '']">
											<br/>
										</xsl:if>
									</dd>
								</p>
							</dl>
						</xsl:for-each>
					</div>
				</xsl:if>
			</xsl:if>
		</xsl:if>
	</xsl:if>
	<!--typo end-->

	<!--translate start-->
	<xsl:if test="not(/yodaodict/basic)">
		<xsl:if test="yodaodict/thirdpart-result/fanyi-result">
			<div class="trans-youdao wrap">
				<div class="item-content">
					<h3 class="sub-item">翻译结果</h3>
				</div>
				<p>
					<xsl:value-of select="yodaodict/thirdpart-result/fanyi-result/input"/>
				</p>
				<p>
					<xsl:value-of select="yodaodict/thirdpart-result/fanyi-result/tran"/>
				</p>
			</div>
		</xsl:if>
	</xsl:if>
	<!--translate end-->


    <!-- 输出关键词、音标、发音小喇叭 -->
	<xsl:if test="/yodaodict/basic/simple-dict/word">
    <h1 class="item-bar">
        <xsl:value-of select="/yodaodict/basic/simple-dict/word/return-phrase"/>
        <span class="phonetic">
			<xsl:if test="/yodaodict/basic/simple-dict/word/phone[text() != '']">
			[<xsl:value-of select="/yodaodict/basic/simple-dict/word/phone"/>]
			</xsl:if>
		</span>
		<nobr>
		<xsl:if test="/yodaodict/basic/simple-dict/word/speech[text() != '']">
		<xsl:element name="a">
			<xsl:attribute name="hidefocus">true</xsl:attribute>
			<xsl:attribute name="class">sp dictvoice</xsl:attribute>
			<xsl:attribute name="title">发音</xsl:attribute>
			<xsl:attribute name="href">#</xsl:attribute>
			<xsl:attribute name="ref">http://dict.youdao.com/dictvoice?audio=<xsl:value-of select="/yodaodict/basic/simple-dict/word/speech"/>&amp;keyfrom=deskdict.mini</xsl:attribute>
			<xsl:attribute name="onmouseover">this.style.cursor='hand';playVoice(this.ref);return true;</xsl:attribute>
			<xsl:attribute name="onmouseout">stopVoice(this.ref);return true;</xsl:attribute>
			<xsl:attribute name="onclick">playVoice(this.ref);return true;</xsl:attribute>
		</xsl:element>
		</xsl:if>
		<xsl:element name="a">
			<xsl:attribute name="hidefocus">true</xsl:attribute>
			<xsl:attribute name="class">sp add-fav</xsl:attribute>
			<xsl:attribute name="title">加入单词本</xsl:attribute>
			<xsl:attribute name="id">addFav</xsl:attribute>
			<xsl:attribute name="ref"><xsl:value-of select="/yodaodict/basic/simple-dict/word/return-phrase"/></xsl:attribute>
			<xsl:attribute name="href">app:addword:<xsl:value-of select="/yodaodict/basic/simple-dict/word/return-phrase" disable-output-escaping="yes"/></xsl:attribute>
			<xsl:attribute name="onclick">ctlog('', '' , 0, 'deskdict.mini' , 1, 'CLICK',  'WordBook');</xsl:attribute>
		</xsl:element>
        <a class="detail" href="app:detail">详细&gt;&gt;
        </a><!--此处 ins标签 和 详细需要在一行-->
		</nobr>
    </h1>
	</xsl:if>


	  <!-- 基本释义开始 -->
	  <xsl:if test="/yodaodict/basic">
		<xsl:if test="/yodaodict/basic/simple-dict">
        <div class="item-content wrap">
			<xsl:for-each select="/yodaodict/basic/simple-dict/word">
				<!-- 循环输出解释项 -->
				<ul class="trans">
				<xsl:for-each select="trs/tr">
				<li>
					<xsl:for-each select="./l/i">
						<xsl:choose>
						 <xsl:when test="@action">
							<!-- 处理link -->
							 <xsl:if test="@action='link'">
								<xsl:choose>
								 <xsl:when test="@href">
									<xsl:element name="a">
										<xsl:attribute name="class">word</xsl:attribute>						
										<xsl:attribute name="href"><xsl:value-of select="@href"/></xsl:attribute>
										<xsl:attribute name="target"><xsl:value-of select="@target"/></xsl:attribute>
										<xsl:value-of select="." />
									</xsl:element>
								</xsl:when>
								<xsl:otherwise>
									<xsl:element name="a">
										<xsl:attribute name="class">word</xsl:attribute>
										<xsl:attribute name="href">app:ds:<xsl:value-of select="." /></xsl:attribute>
										<xsl:value-of select="." />
									</xsl:element>
								</xsl:otherwise>
								</xsl:choose>
							 </xsl:if>
						 </xsl:when>
						 <xsl:otherwise>
							<!-- 如果什么都没有，就如实输出-->
								<xsl:value-of select="." />
						 </xsl:otherwise>
						</xsl:choose>	 
					</xsl:for-each>
				</li>
				</xsl:for-each>
				</ul>

			</xsl:for-each>
		</div>
		</xsl:if>

			<xsl:for-each select="/yodaodict/basic/dict/word">
			<xsl:if test="position() = 1" >
			<!-- 输出关键词、音标、发音小喇叭 -->
			<h1 class="item-bar">
				<xsl:value-of select="./return-phrase"/>
				<span class="phonetic">
					<xsl:if test="./phone[text() != '']">
					[<xsl:value-of select="./phone"/>]
					</xsl:if>
				</span>
				<!-- 输出上标发音 [日语]-->
				<xsl:if test="./phonesup[text()!='']">
				  <sup><xsl:value-of select="./phonesup" /></sup>
				</xsl:if>
				<!-- 域 -->
				<xsl:if test="./field[text()!='']">
				<span class="field"><xsl:value-of select="./field"/></span> 
				</xsl:if>
				<xsl:if test="./origin[text()!='']">
				<span class="origin">【<xsl:value-of select="./origin"/>】</span>
				</xsl:if>

				<nobr>
				<xsl:if test="./speech[text() != '']">
				<xsl:element name="a">
					<xsl:attribute name="hidefocus">true</xsl:attribute>
					<xsl:attribute name="class">sp dictvoice</xsl:attribute>
					<xsl:attribute name="title">发音</xsl:attribute>
					<xsl:attribute name="href">#</xsl:attribute>
					<xsl:attribute name="ref">http://dict.youdao.com/dictvoice?audio=<xsl:value-of select="./speech"/>&amp;keyfrom=deskdict.mini</xsl:attribute>
					<xsl:attribute name="onmouseover">this.style.cursor='hand';playVoice(this.ref);return true;</xsl:attribute>
					<xsl:attribute name="onmouseout">stopVoice(this.ref);return true;</xsl:attribute>
					<xsl:attribute name="onclick">playVoice(this.ref);return true;</xsl:attribute>
				</xsl:element>
				</xsl:if>
				<xsl:element name="a">
					<xsl:attribute name="hidefocus">true</xsl:attribute>
					<xsl:attribute name="class">sp add-fav</xsl:attribute>
					<xsl:attribute name="title">加入单词本</xsl:attribute>
					<xsl:attribute name="id">addFav</xsl:attribute>
					<xsl:attribute name="ref"><xsl:value-of select="./return-phrase"/></xsl:attribute>
					<xsl:attribute name="href">app:addword:<xsl:value-of select="./return-phrase" disable-output-escaping="yes"/></xsl:attribute>
					<xsl:attribute name="onclick">ctlog('', '' , 0, 'deskdict.mini' , 1, 'CLICK',  'WordBook');</xsl:attribute>
				</xsl:element>
				<a class="detail" href="app:detail">详细&gt;&gt;
				</a><!--此处 ins标签 和 详细需要在一行-->
				</nobr>
			</h1>
			</xsl:if>
			<xsl:if test="position() &gt; 1">
			<!-- 输出关键词、音标、发音小喇叭 -->
			<h1 class="item-bar">
				<xsl:value-of select="./return-phrase"/>
				<span class="phonetic">
					<xsl:if test="./phone[text() != '']">
					[<xsl:value-of select="./phone"/>]
					</xsl:if>
				</span>
				<!-- 输出上标发音 [日语]-->
				<xsl:if test="./phonesup[text()!='']">
				  <sup><xsl:value-of select="./phonesup" /></sup>
				</xsl:if>
				<!-- 域 -->
				<xsl:if test="./field[text()!='']">
				<span class="field"><xsl:value-of select="./field"/></span> 
				</xsl:if>
				<xsl:if test="./origin[text()!='']">
				<span class="origin">【<xsl:value-of select="./origin"/>】</span>
				</xsl:if>
				<nobr>
				<xsl:if test="./speech[text() != '']">
					<xsl:element name="a">
						<xsl:attribute name="hidefocus">true</xsl:attribute>
						<xsl:attribute name="class">sp dictvoice</xsl:attribute>
						<xsl:attribute name="title">发音</xsl:attribute>
						<xsl:attribute name="href">#</xsl:attribute>
						<xsl:attribute name="ref">http://dict.youdao.com/dictvoice?audio=<xsl:value-of select="./speech"/>&amp;keyfrom=deskdict.mini</xsl:attribute>
						<xsl:attribute name="onmouseover">this.style.cursor='hand';playVoice(this.ref);return true;</xsl:attribute>
						<xsl:attribute name="onmouseout">stopVoice(this.ref);return true;</xsl:attribute>
						<xsl:attribute name="onclick">playVoice(this.ref);return true;</xsl:attribute>
					</xsl:element>
				</xsl:if>
				</nobr>
			</h1>
			</xsl:if>
								
			<!-- 循环输出解释项 -->
				<div class="item-content wrap">
				<xsl:element name="ul">
				<xsl:attribute name="class">description</xsl:attribute>
				<xsl:if test="./trs/tr">
				<xsl:for-each select="./trs">
					<li>
					<xsl:if test="./pos[text() != '']">
						<span class="pos">[<xsl:value-of select="./pos"/>]</span>
					</xsl:if>
					<xsl:if test="count(./tr) &gt; 1">
						<ul class="trans">
							<xsl:for-each select="./tr">
							<!-- 输出解释 -->
							<li>	
								<xsl:choose>
									<xsl:when test="i">
									<xsl:value-of select="i"/>
									</xsl:when>
									<xsl:otherwise>
										<xsl:apply-templates select="l"/>
									</xsl:otherwise>
									</xsl:choose>
							</li>
							</xsl:for-each>
						</ul>									
					</xsl:if>
					<xsl:if test="count(./tr) &lt; 1 or count(./tr) = 1">
						<xsl:for-each select="./tr">
						<!-- 输出解释 -->
							<xsl:choose>
								<xsl:when test="i">
								<xsl:value-of select="i"/>
								</xsl:when>
								<xsl:otherwise>
									<xsl:apply-templates select="l"/>
								</xsl:otherwise>
								</xsl:choose>
						</xsl:for-each>								
					</xsl:if>
					</li>
				</xsl:for-each>
				</xsl:if>
				<xsl:if test="not(./trs/tr)">
					<xsl:for-each select="./trs">
						<li>
							<xsl:if test="./pos[text() != '']">
								<span class="pos">[<xsl:value-of select="./pos"/>]</span>
							</xsl:if>
							<xsl:choose>
								<xsl:when test="i">
								<xsl:value-of select="./i"/>
							</xsl:when>
							<xsl:otherwise>
								<xsl:apply-templates select="./l"/>
							</xsl:otherwise>
							</xsl:choose>
						</li>
					</xsl:for-each>
				</xsl:if>
				</xsl:element>
				</div>
		  </xsl:for-each>
	  </xsl:if>

	  <!-- 网络释义开始 -->
      <xsl:if test="yodaodict/yodao-web-dict/web-translation">
                <xsl:for-each select="yodaodict/yodao-web-dict/web-translation">
                  <!-- 输出第一个网络释义 -->
                  <xsl:if test="position() = 1" >
                    <xsl:if test="./@same">
						<xsl:if test="not(/yodaodict/basic/simple-dict/word) and not(/yodaodict/basic/dict/word)">
							<h1 class="item-bar">
								<xsl:value-of select="/yodaodict/input"/>
								<nobr>
								<xsl:element name="a">
									<xsl:attribute name="hidefocus">true</xsl:attribute>
									<xsl:attribute name="class">sp add-fav</xsl:attribute>
									<xsl:attribute name="title">加入单词本</xsl:attribute>
									<xsl:attribute name="id">addFav</xsl:attribute>
									<xsl:attribute name="ref"><xsl:value-of select="/yodaodict/input"/></xsl:attribute>
									<xsl:attribute name="href">app:addword:<xsl:value-of select="/yodaodict/input" disable-output-escaping="yes"/></xsl:attribute>
									<xsl:attribute name="onclick">ctlog('', '' , 0, 'deskdict.mini' , 1, 'CLICK',  'WordBook');</xsl:attribute>
								</xsl:element>
								<a class="detail" href="app:detail">详细&gt;&gt;
								</a><!--此处 ins标签 和 详细需要在一行-->
								</nobr>
							</h1>
						</xsl:if>

				<div class="item-content wrap">
					<h3 class="sub-item">网络释义<span>┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈┈</span></h3>

					<ul class="trans">
						<li>
						<xsl:for-each select="./trans">
								<span class="translation">
								<xsl:if test="./cls">
									<font color="#959595">
										<xsl:for-each select="./cls/cl">[<xsl:value-of select="."/>]</xsl:for-each>
									</font>&#160;
								</xsl:if>
								<xsl:value-of select="./value"/>
								<xsl:if test="position() != last()">
									<ins></ins>
								</xsl:if>
								</span>
						</xsl:for-each>
						</li>
					</ul>
					</div>
                    </xsl:if>
                  </xsl:if>
                </xsl:for-each>
      </xsl:if>
      <!-- 网络释义的结束 -->

	<!--无网络结果开始-->
	<xsl:if test="/yodaodict/custom-translation/translation">
		<h1 class="item-bar">
			<xsl:value-of select="/yodaodict/input"/>
			<nobr>
			<xsl:element name="a">
				<xsl:attribute name="hidefocus">true</xsl:attribute>
				<xsl:attribute name="class">sp add-fav</xsl:attribute>
				<xsl:attribute name="title">加入单词本</xsl:attribute>
				<xsl:attribute name="id">addFav</xsl:attribute>
				<xsl:attribute name="ref"><xsl:value-of select="/yodaodict/input"/></xsl:attribute>
				<xsl:attribute name="href">app:addword:<xsl:value-of select="/yodaodict/input" disable-output-escaping="yes"/></xsl:attribute>
				<xsl:attribute name="onclick">ctlog('', '' , 0, 'deskdict.mini' , 1, 'CLICK',  'WordBook');</xsl:attribute>
			</xsl:element>
			<a class="detail" href="app:detail">详细&gt;&gt;</a><!--此处 ins标签 和 详细需要在一行-->
			</nobr>
		</h1>
		<div class="item-content wrap">
		<ul class="description">
			<xsl:for-each select="/yodaodict/custom-translation/translation">
				<li>
					<xsl:value-of select="./content"/>
				</li>				
			</xsl:for-each>
		</ul>
		</div>
	</xsl:if>

	<xsl:if test="/yodaodict/custom-translation/translation">
		<br />
		<p class="wrap tips-msg" >
			目前无法连接服务器，请检查您的网络连接或者查看<a href="../res/faq.html" target="_blank">FAQ页面</a>。
		</p>
	</xsl:if>

	<!--无网络结果结束-->
	
	<!-- 没有结果的情况  -->
	<xsl:if test="not(yodaodict/basic/dict)">
		<xsl:if test="not(/yodaodict/basic/simple-dict)">
			<xsl:if test="not(yodaodict/yodao-web-dict/web-translation[1]/@same)">
			        <xsl:if test="not(yodaodict/thirdpart-result/fanyi-result)">
				<xsl:if test="not(yodaodict/local-dicts/dict/word[text() != ''])">
				<xsl:if test="not(/yodaodict/custom-translation/translation)">
					<h1 class="item-bar">
											<xsl:choose>
						<xsl:when test = "/yodaodict/original-query">
							<xsl:value-of select="/yodaodict/original-query" />
						</xsl:when>
						<xsl:otherwise>
							<xsl:value-of select="/yodaodict/input" />
						</xsl:otherwise>
					</xsl:choose>
						<nobr>
						<xsl:element name="a">
							<xsl:attribute name="hidefocus">true</xsl:attribute>
							<xsl:attribute name="class">sp add-fav</xsl:attribute>
							<xsl:attribute name="title">加入单词本</xsl:attribute>
							<xsl:attribute name="id">addFav</xsl:attribute>
							<xsl:attribute name="ref">
					<xsl:choose>
						<xsl:when test = "/yodaodict/original-query">
							<xsl:value-of select="/yodaodict/original-query" />
						</xsl:when>
						<xsl:otherwise>
							<xsl:value-of select="/yodaodict/input" />
						</xsl:otherwise>
					</xsl:choose>
							</xsl:attribute>
							<xsl:attribute name="href">app:addword:<xsl:value-of select="/yodaodict/input" disable-output-escaping="yes"/></xsl:attribute>
							<xsl:attribute name="onclick">ctlog('', '' , 0, 'deskdict.mini' , 1, 'CLICK',  'WordBook');</xsl:attribute>
						</xsl:element>
						<a class="detail" href="app:detail">详细&gt;&gt;</a><!--此处 ins标签 和 详细需要在一行-->
						</nobr>
					</h1>
					<br />
					<p class="tips-msg wrap" >
						没有找到相关的<b><xsl:call-template name="get_language_name"><xsl:with-param name="lang_type" select="/yodaodict/lang" /></xsl:call-template></b>结果。
					</p>
				</xsl:if>
				</xsl:if>
				</xsl:if>
			</xsl:if>
		</xsl:if>
	</xsl:if>

	<!-- 结果底部版权声明开始 -->
	<!-- 简明翻译来源的声明 -->
<xsl:if test="yodaodict/basic/simple-dict or yodaodict/basic/dict or yodaodict/baike or yodaodict/thirdpart-result/fanyi-result">
		<!-- 显示一条黑色的横线 -->
		  <ul class="copyright">
          <xsl:if test="yodaodict/basic/simple-dict/source">
            <li id="btsource">
              简明翻译结果来源于:
              <xsl:choose>
                <xsl:when test="yodaodict/basic/simple-dict/source/url">
                  <xsl:element name="a">
                    <xsl:attribute name="href">
                      <xsl:value-of select="yodaodict/basic/simple-dict/source/url"/>
                    </xsl:attribute>
                    <xsl:attribute name="class">bottomsource</xsl:attribute>
                    <xsl:attribute name="target">_blank</xsl:attribute>
                    <xsl:attribute name="onclick">
                      javascript:ctlog(this, '<xsl:call-template name="standard_return_phrase" />', 1, 'dict.mini', 1, 'CLICK', 'simple_result')
                    </xsl:attribute>
                    <xsl:value-of select="yodaodict/basic/simple-dict/source/name"/>
                  </xsl:element>
                </xsl:when>
                <xsl:otherwise>
                  <xsl:value-of select="yodaodict/basic/simple-dict/source/name"/>
                </xsl:otherwise>
              </xsl:choose>
            </li>
          </xsl:if>
          <!-- 其他词典的来源声明-->
          <!-- 结果底部版权声明结束 -->
          <xsl:if test="yodaodict/basic/dict/source">
            <li id="btsource">
              <xsl:value-of select="yodaodict/basic/name"/>来源于:
              <xsl:value-of select="yodaodict/basic/dict/source/name"/>
            </li>
          </xsl:if>
		  
		  <xsl:if test="not(/yodaodict/basic)">
			<xsl:if test="yodaodict/thirdpart-result/fanyi-result">
				<li id="btsource">
					翻译结果来源于:
					<xsl:element name="a">
                    <xsl:attribute name="href">
                      http://fanyi.youdao.com/
                    </xsl:attribute>
                    <xsl:attribute name="class">bottomsource</xsl:attribute>
                    <xsl:attribute name="target">_blank</xsl:attribute>
                    <xsl:attribute name="onclick">
                      javascript:ctlog(this, '<xsl:call-template name="standard_return_phrase" />', 1, 'dict.mini', 1, 'CLICK', 'fanyi_result')
                    </xsl:attribute>
                    有道翻译
                  </xsl:element>
				</li>
			</xsl:if>
		  </xsl:if>
        </ul>
</xsl:if>

</div>

</body>
</html>
</xsl:template>
  
</xsl:stylesheet>