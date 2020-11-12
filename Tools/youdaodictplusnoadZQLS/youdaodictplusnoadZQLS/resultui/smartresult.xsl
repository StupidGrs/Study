<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:template match="/">
<html>
<head>
<title>result</title>
</head>
<body>
<xsl:if test="smartresult/entry/type = 'wiki'">
<table>
    <tr>
        <td class="description">
	    <span class="smallTitle">
	    <xsl:element name="a">
		<xsl:attribute name="target">_blank</xsl:attribute>
		<xsl:attribute name="href">
		    <xsl:value-of select="/smartresult/entry/url"/>
		</xsl:attribute>
		<xsl:value-of select="/smartresult/entry/title"/>
	    </xsl:element>
	    </span>
	    <br/>
	    <xsl:value-of select="/smartresult/entry/summary"/>
	    <span class="more">
	    <xsl:element name="a">
		<xsl:attribute name="target">_blank</xsl:attribute>
		<xsl:attribute name="href">
		    <xsl:value-of select="/smartresult/entry/url"/>
		</xsl:attribute>更多&gt;&gt;
	    </xsl:element>
	    </span>
	</td>
	<td>
	    <xsl:if test="/smartresult/entry/image">
	        <xsl:element name="img">
                    <xsl:attribute name="src">
                        <xsl:value-of select="/smartresult/entry/image"/>
                    </xsl:attribute>
                    <xsl:attribute name="width">80</xsl:attribute>
                    <xsl:attribute name="height">80</xsl:attribute>
                </xsl:element>
	    </xsl:if>
	</td>
    </tr>
</table>
</xsl:if>
</body>
</html>
</xsl:template>
</xsl:stylesheet>
