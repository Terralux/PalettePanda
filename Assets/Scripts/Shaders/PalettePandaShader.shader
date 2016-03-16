// Upgrade NOTE: commented out 'float4 unity_DynamicLightmapST', a built-in variable
// Upgrade NOTE: commented out 'float4 unity_LightmapST', a built-in variable

// Shader created with Shader Forge v1.02 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.02;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:1,uamb:True,mssp:True,lmpd:False,lprd:False,rprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,blpr:0,bsrc:0,bdst:1,culm:0,dpts:2,wrdp:True,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:9662,x:34370,y:33431,varname:node_9662,prsc:2|diff-2398-OUT,amdfl-6940-OUT,difocc-4965-OUT;n:type:ShaderForge.SFN_Tex2d,id:885,x:31972,y:33371,ptovrint:False,ptlb:BaseTexture,ptin:_BaseTexture,varname:node_885,prsc:2,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False;n:type:ShaderForge.SFN_ViewVector,id:8848,x:31612,y:32839,varname:node_8848,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:2808,x:31612,y:32671,prsc:2,pt:False;n:type:ShaderForge.SFN_Dot,id:147,x:31806,y:32742,varname:node_147,prsc:2,dt:0|A-2808-OUT,B-8848-OUT;n:type:ShaderForge.SFN_If,id:8734,x:32176,y:32827,varname:node_8734,prsc:2|A-4951-OUT,B-9745-OUT,GT-6658-OUT,EQ-1321-OUT,LT-1321-OUT;n:type:ShaderForge.SFN_Slider,id:9745,x:31634,y:33296,ptovrint:False,ptlb:RimLightThickness,ptin:_RimLightThickness,varname:node_9745,prsc:2,min:0,cur:0.8,max:1;n:type:ShaderForge.SFN_Vector1,id:1321,x:31809,y:33212,varname:node_1321,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:6658,x:31809,y:33167,varname:node_6658,prsc:2,v1:1;n:type:ShaderForge.SFN_OneMinus,id:4951,x:31977,y:32742,varname:node_4951,prsc:2|IN-147-OUT;n:type:ShaderForge.SFN_If,id:4220,x:32223,y:33242,varname:node_4220,prsc:2|A-1996-OUT,B-885-RGB,GT-1321-OUT,EQ-6658-OUT,LT-6658-OUT;n:type:ShaderForge.SFN_Vector1,id:1996,x:31809,y:33106,varname:node_1996,prsc:2,v1:0.9;n:type:ShaderForge.SFN_Add,id:1472,x:32816,y:33104,varname:node_1472,prsc:2|A-2303-OUT,B-555-OUT;n:type:ShaderForge.SFN_Clamp01,id:4256,x:33018,y:33155,varname:node_4256,prsc:2|IN-1472-OUT;n:type:ShaderForge.SFN_If,id:3406,x:32223,y:33455,varname:node_3406,prsc:2|A-2165-OUT,B-885-RGB,GT-1321-OUT,EQ-6658-OUT,LT-6658-OUT;n:type:ShaderForge.SFN_Vector1,id:2165,x:31955,y:33550,varname:node_2165,prsc:2,v1:0.5;n:type:ShaderForge.SFN_ViewVector,id:2463,x:31599,y:33709,varname:node_2463,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:8522,x:31599,y:33541,prsc:2,pt:False;n:type:ShaderForge.SFN_Dot,id:2438,x:31798,y:33625,varname:node_2438,prsc:2,dt:0|A-8522-OUT,B-2463-OUT;n:type:ShaderForge.SFN_If,id:1804,x:32223,y:33625,varname:node_1804,prsc:2|A-1731-OUT,B-7149-OUT,GT-6658-OUT,EQ-1321-OUT,LT-1321-OUT;n:type:ShaderForge.SFN_OneMinus,id:1731,x:31969,y:33625,varname:node_1731,prsc:2|IN-2438-OUT;n:type:ShaderForge.SFN_Slider,id:7149,x:31678,y:33942,ptovrint:False,ptlb:RimShadingThickness,ptin:_RimShadingThickness,varname:node_9745,prsc:2,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_Add,id:5319,x:32450,y:33529,varname:node_5319,prsc:2|A-1804-OUT,B-3406-OUT;n:type:ShaderForge.SFN_Color,id:6570,x:32971,y:33734,ptovrint:False,ptlb:RimShadingColor,ptin:_RimShadingColor,varname:node_626,prsc:2,glob:False,c1:0.328,c2:0.328,c3:0.328,c4:0.322;n:type:ShaderForge.SFN_Multiply,id:6957,x:33234,y:33629,varname:node_6957,prsc:2|A-6570-RGB,B-5932-OUT;n:type:ShaderForge.SFN_Multiply,id:5932,x:32999,y:33520,varname:node_5932,prsc:2|A-4567-OUT,B-5881-OUT;n:type:ShaderForge.SFN_Vector1,id:5881,x:32761,y:33626,varname:node_5881,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Clamp01,id:4567,x:32636,y:33529,varname:node_4567,prsc:2|IN-5319-OUT;n:type:ShaderForge.SFN_Slider,id:3465,x:33630,y:33626,ptovrint:False,ptlb:DiffuseAmbientLightValue,ptin:_DiffuseAmbientLightValue,varname:node_3465,prsc:2,min:0,cur:0.7,max:1;n:type:ShaderForge.SFN_Slider,id:9001,x:33633,y:33909,ptovrint:False,ptlb:DiffuseAmbientOcclusionValue,ptin:_DiffuseAmbientOcclusionValue,varname:node_3465,prsc:2,min:0,cur:0.7,max:1;n:type:ShaderForge.SFN_Color,id:7926,x:33518,y:33733,ptovrint:False,ptlb:DiffuseAmbientLightColor,ptin:_DiffuseAmbientLightColor,varname:node_7926,prsc:2,glob:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:6940,x:33949,y:33661,varname:node_6940,prsc:2|A-3465-OUT,B-7926-RGB;n:type:ShaderForge.SFN_Color,id:2833,x:33512,y:34013,ptovrint:False,ptlb:DiffuseAmbientOcclusionColor,ptin:_DiffuseAmbientOcclusionColor,varname:node_7926,prsc:2,glob:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:4965,x:33958,y:33948,varname:node_4965,prsc:2|A-9001-OUT,B-2833-RGB;n:type:ShaderForge.SFN_If,id:278,x:32434,y:33272,varname:node_278,prsc:2|A-885-RGB,B-1328-OUT,GT-1321-OUT,EQ-1321-OUT,LT-885-RGB;n:type:ShaderForge.SFN_Vector1,id:1328,x:31955,y:33797,varname:node_1328,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Color,id:6091,x:32161,y:33022,ptovrint:False,ptlb:RimLightColor,ptin:_RimLightColor,varname:node_626,prsc:2,glob:False,c1:0,c2:1,c3:0,c4:1;n:type:ShaderForge.SFN_Multiply,id:4701,x:32434,y:33145,varname:node_4701,prsc:2|A-6091-RGB,B-4220-OUT;n:type:ShaderForge.SFN_If,id:555,x:32630,y:33171,varname:node_555,prsc:2|A-4701-OUT,B-278-OUT,GT-4701-OUT,EQ-4701-OUT,LT-278-OUT;n:type:ShaderForge.SFN_If,id:2398,x:33502,y:33419,varname:node_2398,prsc:2|A-4511-OUT,B-5881-OUT,GT-4256-OUT,EQ-4256-OUT,LT-6957-OUT;n:type:ShaderForge.SFN_Multiply,id:2303,x:32415,y:32794,varname:node_2303,prsc:2|A-6091-RGB,B-8734-OUT;n:type:ShaderForge.SFN_Add,id:4077,x:32661,y:33328,varname:node_4077,prsc:2|A-4220-OUT,B-278-OUT;n:type:ShaderForge.SFN_Multiply,id:8384,x:32832,y:33342,varname:node_8384,prsc:2|A-4077-OUT,B-2275-OUT;n:type:ShaderForge.SFN_Vector1,id:2275,x:32494,y:33454,varname:node_2275,prsc:2,v1:10;n:type:ShaderForge.SFN_Clamp01,id:4511,x:33198,y:33339,varname:node_4511,prsc:2|IN-105-OUT;n:type:ShaderForge.SFN_Add,id:105,x:33018,y:33299,varname:node_105,prsc:2|A-8384-OUT,B-8734-OUT;proporder:885-9745-6091-7149-6570-3465-7926-9001-2833;pass:END;sub:END;*/

Shader "Shader Forge/PalettePandaShader" {
    Properties {
        _BaseTexture ("BaseTexture", 2D) = "white" {}
        _RimLightThickness ("RimLightThickness", Range(0, 1)) = 0.8
        _RimLightColor ("RimLightColor", Color) = (0,1,0,1)
        _RimShadingThickness ("RimShadingThickness", Range(0, 1)) = 0.5
        _RimShadingColor ("RimShadingColor", Color) = (0.328,0.328,0.328,0.322)
        _DiffuseAmbientLightValue ("DiffuseAmbientLightValue", Range(0, 1)) = 0.7
        _DiffuseAmbientLightColor ("DiffuseAmbientLightColor", Color) = (0.5,0.5,0.5,1)
        _DiffuseAmbientOcclusionValue ("DiffuseAmbientOcclusionValue", Range(0, 1)) = 0.7
        _DiffuseAmbientOcclusionColor ("DiffuseAmbientOcclusionColor", Color) = (0.5,0.5,0.5,1)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "ForwardBase"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _LightColor0;
            // float4 unity_LightmapST;
            #ifdef DYNAMICLIGHTMAP_ON
                // float4 unity_DynamicLightmapST;
            #endif
            uniform sampler2D _BaseTexture; uniform float4 _BaseTexture_ST;
            uniform float _RimLightThickness;
            uniform float _RimShadingThickness;
            uniform float4 _RimShadingColor;
            uniform float _DiffuseAmbientLightValue;
            uniform float _DiffuseAmbientOcclusionValue;
            uniform float4 _DiffuseAmbientLightColor;
            uniform float4 _DiffuseAmbientOcclusionColor;
            uniform float4 _RimLightColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
                #ifndef LIGHTMAP_OFF
                    float4 uvLM : TEXCOORD6;
                #else
                    float3 shLight : TEXCOORD6;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(_Object2World, float4(v.normal,0)).xyz;
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 indirectDiffuse = float3(0,0,0);
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                indirectDiffuse += (_DiffuseAmbientLightValue*_DiffuseAmbientLightColor.rgb); // Diffuse Ambient Light
                indirectDiffuse *= (_DiffuseAmbientOcclusionValue*_DiffuseAmbientOcclusionColor.rgb); // Diffuse AO
                float node_1996 = 0.9;
                float4 _BaseTexture_var = tex2D(_BaseTexture,TRANSFORM_TEX(i.uv0, _BaseTexture));
                float node_4220_if_leA = step(node_1996,_BaseTexture_var.rgb);
                float node_4220_if_leB = step(_BaseTexture_var.rgb,node_1996);
                float node_6658 = 1.0;
                float node_1321 = 0.0;
                float3 node_4220 = lerp((node_4220_if_leA*node_6658)+(node_4220_if_leB*node_1321),node_6658,node_4220_if_leA*node_4220_if_leB);
                float node_1328 = 0.2;
                float node_278_if_leA = step(_BaseTexture_var.rgb,node_1328);
                float node_278_if_leB = step(node_1328,_BaseTexture_var.rgb);
                float3 node_278 = lerp((node_278_if_leA*_BaseTexture_var.rgb)+(node_278_if_leB*node_1321),node_1321,node_278_if_leA*node_278_if_leB);
                float node_8734_if_leA = step((1.0 - dot(i.normalDir,viewDirection)),_RimLightThickness);
                float node_8734_if_leB = step(_RimLightThickness,(1.0 - dot(i.normalDir,viewDirection)));
                float node_8734 = lerp((node_8734_if_leA*node_1321)+(node_8734_if_leB*node_6658),node_1321,node_8734_if_leA*node_8734_if_leB);
                float node_5881 = 0.5;
                float node_2398_if_leA = step(saturate((((node_4220+node_278)*10.0)+node_8734)),node_5881);
                float node_2398_if_leB = step(node_5881,saturate((((node_4220+node_278)*10.0)+node_8734)));
                float node_1804_if_leA = step((1.0 - dot(i.normalDir,viewDirection)),_RimShadingThickness);
                float node_1804_if_leB = step(_RimShadingThickness,(1.0 - dot(i.normalDir,viewDirection)));
                float node_3406_if_leA = step(0.5,_BaseTexture_var.rgb);
                float node_3406_if_leB = step(_BaseTexture_var.rgb,0.5);
                float3 node_4567 = saturate((lerp((node_1804_if_leA*node_1321)+(node_1804_if_leB*node_6658),node_1321,node_1804_if_leA*node_1804_if_leB)+lerp((node_3406_if_leA*node_6658)+(node_3406_if_leB*node_1321),node_6658,node_3406_if_leA*node_3406_if_leB)));
                float3 node_5932 = (node_4567*node_5881);
                float3 node_6957 = (_RimShadingColor.rgb*node_5932);
                float3 node_4701 = (_RimLightColor.rgb*node_4220);
                float node_555_if_leA = step(node_4701,node_278);
                float node_555_if_leB = step(node_278,node_4701);
                float3 node_4256 = saturate(((_RimLightColor.rgb*node_8734)+lerp((node_555_if_leA*node_278)+(node_555_if_leB*node_4701),node_4701,node_555_if_leA*node_555_if_leB)));
                float3 node_2398 = lerp((node_2398_if_leA*node_6957)+(node_2398_if_leB*node_4256),node_4256,node_2398_if_leA*node_2398_if_leB);
                float3 diffuse = (directDiffuse + indirectDiffuse) * node_2398;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ForwardAdd"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _LightColor0;
            // float4 unity_LightmapST;
            #ifdef DYNAMICLIGHTMAP_ON
                // float4 unity_DynamicLightmapST;
            #endif
            uniform sampler2D _BaseTexture; uniform float4 _BaseTexture_ST;
            uniform float _RimLightThickness;
            uniform float _RimShadingThickness;
            uniform float4 _RimShadingColor;
            uniform float4 _RimLightColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                #ifndef LIGHTMAP_OFF
                    float4 uvLM : TEXCOORD5;
                #else
                    float3 shLight : TEXCOORD5;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(_Object2World, float4(v.normal,0)).xyz;
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float node_1996 = 0.9;
                float4 _BaseTexture_var = tex2D(_BaseTexture,TRANSFORM_TEX(i.uv0, _BaseTexture));
                float node_4220_if_leA = step(node_1996,_BaseTexture_var.rgb);
                float node_4220_if_leB = step(_BaseTexture_var.rgb,node_1996);
                float node_6658 = 1.0;
                float node_1321 = 0.0;
                float3 node_4220 = lerp((node_4220_if_leA*node_6658)+(node_4220_if_leB*node_1321),node_6658,node_4220_if_leA*node_4220_if_leB);
                float node_1328 = 0.2;
                float node_278_if_leA = step(_BaseTexture_var.rgb,node_1328);
                float node_278_if_leB = step(node_1328,_BaseTexture_var.rgb);
                float3 node_278 = lerp((node_278_if_leA*_BaseTexture_var.rgb)+(node_278_if_leB*node_1321),node_1321,node_278_if_leA*node_278_if_leB);
                float node_8734_if_leA = step((1.0 - dot(i.normalDir,viewDirection)),_RimLightThickness);
                float node_8734_if_leB = step(_RimLightThickness,(1.0 - dot(i.normalDir,viewDirection)));
                float node_8734 = lerp((node_8734_if_leA*node_1321)+(node_8734_if_leB*node_6658),node_1321,node_8734_if_leA*node_8734_if_leB);
                float node_5881 = 0.5;
                float node_2398_if_leA = step(saturate((((node_4220+node_278)*10.0)+node_8734)),node_5881);
                float node_2398_if_leB = step(node_5881,saturate((((node_4220+node_278)*10.0)+node_8734)));
                float node_1804_if_leA = step((1.0 - dot(i.normalDir,viewDirection)),_RimShadingThickness);
                float node_1804_if_leB = step(_RimShadingThickness,(1.0 - dot(i.normalDir,viewDirection)));
                float node_3406_if_leA = step(0.5,_BaseTexture_var.rgb);
                float node_3406_if_leB = step(_BaseTexture_var.rgb,0.5);
                float3 node_4567 = saturate((lerp((node_1804_if_leA*node_1321)+(node_1804_if_leB*node_6658),node_1321,node_1804_if_leA*node_1804_if_leB)+lerp((node_3406_if_leA*node_6658)+(node_3406_if_leB*node_1321),node_6658,node_3406_if_leA*node_3406_if_leB)));
                float3 node_5932 = (node_4567*node_5881);
                float3 node_6957 = (_RimShadingColor.rgb*node_5932);
                float3 node_4701 = (_RimLightColor.rgb*node_4220);
                float node_555_if_leA = step(node_4701,node_278);
                float node_555_if_leB = step(node_278,node_4701);
                float3 node_4256 = saturate(((_RimLightColor.rgb*node_8734)+lerp((node_555_if_leA*node_278)+(node_555_if_leB*node_4701),node_4701,node_555_if_leA*node_555_if_leB)));
                float3 node_2398 = lerp((node_2398_if_leA*node_6957)+(node_2398_if_leB*node_4256),node_4256,node_2398_if_leA*node_2398_if_leB);
                float3 diffuse = directDiffuse * node_2398;
/// Final Color:
                float3 finalColor = diffuse;
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
