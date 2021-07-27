<template>
    <div style="width:100%">
        <el-steps :active="active" finish-status="success">
  <el-step title="选择砍价商品"></el-step>
  <el-step title="填写基础信息"></el-step>
  <el-step title="修改商品详情"></el-step>
</el-steps>
//模块1
<div v-if="active==0">
      <div>
        <span>选择商品</span>
        
        <el-button icon="el-icon-camera" circle @click="GoodsInfo()"></el-button>
        <img id="BackImg" :src="'http://10.3.181.32:53590'+this.img.toString()" alt="" 
         onerror="this.src='https://cube.elemecdn.com/6/94/4d3ea53c084bad6931a56d5158a48jpeg.jpeg'" style="width:80px;height:80px">
    <el-dialog
    title="商品列表"
   :visible.sync="dialogGoods"
   width="50%"
   :before-close="handleclose"
    >
  <el-table
    ref="multipleTable"
    :data="tableData"
    tooltip-effect="dark"
    style="width: 100%"
    @selection-change="handleSelectionChange">
    <el-table-column
      type="selection"
      width="55">
    </el-table-column>
    <el-table-column
      prop="goodsId"
      label="ID">
    </el-table-column>
     <el-table-column
      prop="goodsPicture"
      label="商品图">
      <template slot-scope="scope">
        <img :src="'http://10.3.181.32:53590'+scope.row.goodsPicture" style="width:80px;height:80px">
      </template>
    </el-table-column>
    <el-table-column
      prop="goodsName"
      label="商品名称">
    </el-table-column>
    <el-table-column
      prop="goodsOneName"
      label="商品分类">
    </el-table-column>
  </el-table>

    </el-dialog>
    
    </div>
    <el-button style="margin-top: 12px;" @click="active1">下一步</el-button>
</div>


//模块2
<div v-if="active==1">
   <el-form
      ref="ruleForm"
      :model="ruleForm"
      :rules="rules"
      label-width="100px"
      class="demo-ruleForm"
    >
      <div class="MesBox">
        <div class="left">
          <el-form-item label="商品轮播图">
            <img :src="'http://10.3.181.32:53590'+ ruleForm.CutImg" width="100" height="100" />
          </el-form-item>

          <el-form-item label="砍价活动名称" prop="CutName" >
            <el-input v-model="ruleForm.CutName" :disabled="true"></el-input>
          </el-form-item>

          <el-form-item label="砍价活动简介" prop="CutIntro">
            <el-input v-model="ruleForm.CutIntro"></el-input>
          </el-form-item>

          <el-form-item label="单位" prop="CutUnit">
            <el-input v-model="ruleForm.CutUnit"></el-input>
          </el-form-item>
          <el-form-item label="排序" prop="CutSort">
            <el-input-number
              v-model="ruleForm.CutSort"
              @change="handleChange"
              :min="1"
              :max="10"
            ></el-input-number>
          </el-form-item>
          <el-form-item class="btime" label="活动日期">
            <el-date-picker v-model="ruleForm.BeginTime" type="date" placeholder="开始时间"></el-date-picker>
            <span>至</span>
            <el-date-picker v-model="ruleForm.EndTime" type="date" placeholder="结束时间"></el-date-picker>
          </el-form-item>

          <el-form-item label="砍价人数" prop="CutPeople">
            <el-input-number
              v-model="ruleForm.CutPeople"
              @change="handleChange"
              :min="1"
              :max="10"
              label="描述文字"
            ></el-input-number>
          </el-form-item>

          <el-form-item label="砍价次数" prop="CutNumber">
            <el-input-number
              v-model="ruleForm.CutNumber"
              @change="handleChange"
              :min="1"
              :max="10"
              label="描述文字"
            ></el-input-number>
          </el-form-item>

          <el-form-item label="购买数量限制" prop="NumberLimited">
            <el-input-number
              v-model="ruleForm.NumberLimited"
              @change="handleChange"
              :min="1"
              :max="10"
              label="描述文字"
            ></el-input-number>
          </el-form-item>
          <!-- <el-form-item label="运费模板" prop="Freight">
            <el-select v-model="Freight" placeholder="请选择">
              <el-option
                v-for="(item, i) in options"
                :key="i"
                :label="item.freightName"
                :value="item.freightId"
              ></el-option>
            </el-select>
          </el-form-item> -->
      <el-form-item label="运费模板" prop="Freight">
  <el-select v-model="value"  placeholder="请选择">
    <el-option
      v-for="item in options"
      :key="item.freightTypeId"
      :label="item.freightName"
      :value="item.freightTypeId">
    </el-option>
  </el-select>
  </el-form-item>
          <el-form-item label="活动状态">
            <el-radio v-model="ruleForm.CutState" :label="0">关闭</el-radio>
            <el-radio v-model="ruleForm.CutState" :label="1">开启</el-radio>
          </el-form-item>
          <el-form-item label="商品属性">
            <el-table
              :data="Attribute"
              border
              style="width: 80000px"
              :ref="multipleTable"
              @selection-change="handleSelectionChange2"
            >
              <el-table-column type="selection" width="55"></el-table-column>
              <el-table-column label="图片" width="180">
                <template slot-scope="scope">
                  <img :src="'http://10.3.181.32:53590'+ scope.row.picture" width="60" height="60" />
                </template>
              </el-table-column>

              <el-table-column label="砍价金额" width="220">
                <template slot-scope="scope">
                  <el-input-number
                    v-model="scope.row.cutPrice"
                    @change="handleChange"
                    :precision="2"
                    :step="1"
                  ></el-input-number>
                </template>
              </el-table-column>
              <el-table-column label="成本价">
                <template slot-scope="scope">
                  <span>{{ scope.row.costPrice }}</span>
                </template>
              </el-table-column>
              <el-table-column label="原价">
                <template slot-scope="scope">
                  <span>{{ scope.row.originalPrice }}</span>
                </template>
              </el-table-column>
              <el-table-column label="库存">
                <template slot-scope="scope">
                  <span>{{ scope.row.inventory }}</span>
                </template>
              </el-table-column>
              <el-table-column label="限量" width="220">
                <template slot-scope="scope">
                  <el-input-number v-model="scope.row.limited" @change="handleChange" :step="1"></el-input-number>
                </template>
              </el-table-column>

              <el-table-column label="重量">
                <template slot-scope="scope">
                  <span>{{ scope.row.weight }}</span>
                </template>
              </el-table-column>
              <el-table-column label="体积">
                <template slot-scope="scope">
                  <span>{{ scope.row.bulk }}</span>
                </template>
              </el-table-column>
              <el-table-column label="商品编号">
                <template slot-scope="scope">
                  <span>{{ scope.row.goodsSerial }}</span>
                </template>
              </el-table-column>
              <el-table-column prop="GoodsProperty" label></el-table-column>
            </el-table>
          </el-form-item>
      
        </div>
        <el-button style="margin-top: 12px;" @click="active2">下一步</el-button>
      </div>
    </el-form>
</div>
<div v-if="active==2">
  <div>
    <quill-editor ref="text" v-model="ruleForm.CutIntro" class="myQuillEditor" :options="editorOption" style="height:400px" />
  </div>
 <br>
 <br>
<el-button  style="margin-top: 12px;" @click="detail">完成</el-button>
</div>
<!-- <step-one v-if="active===0"></step-one>
<step-two v-if="active===1"></step-two>
<step-three v-if="active===2"></step-three> -->
<!-- <el-button style="margin-top: 12px;" @click="next">下一步</el-button>
 <el-button v-if="this.active === 2 ? true :false" style="margin-top: 12px;" @click="detail">完成</el-button> -->
    </div>
</template>
<script>
import axios from 'axios';
import {Loading} from 'element-ui'
import E from 'wangeditor'


var editor;
import StepOne from "@/pages/Bargain/Goods/stepChidren/stepone"
import StepTwo from "@/pages/Bargain/Goods/stepChidren/steptwo"
import StepThree from "@/pages/Bargain/Goods/stepChidren/stepthree"
    export default {
      name: "WriteArticle",
components: {
    //注册组件
    StepOne,
    StepTwo,
    StepThree
  },
      data() {
        return {
          //active=0
          dialogGoods:false,
         tableData: [],
          multipleSelection: [],
          GoodsId:'',
          ids:[],
           img:[],
          active: 0,
          //active=1
          GoodsId:'',
        
        ruleForm: {
        CutImg:"",
        CutName: "",
        CutIntro: "",
        CutUnit:"",
        CutPrice:0,
        CutSort: 0,
        BeginTime: "",
        EndTime: "",
        CutPeople: 0,
        Freight: "",
        CutNumber: 0,
        Bargain_Amount:0,
        NumberLimited: 0,
        CutState: 1,
        GoodsProperty: 0,
        CutSuccess:0,
        CutPartici:0,
        Limited:0,
        LimitedResidue:0,
        BargainState:0,
        },
        GoodsForm:[],
        Attribute:[],
        options:[],
        value:'',
        // That:{
        //   Title:'',
        // Content:''
        // }
        }
      },
      created(){
         this.GetBargainData();
         this.GoodsData();
       
      },
      methods:{
         GoodsInfo(){
      this.dialogGoods=true;
      this.ids=[];
      this.img=[];
      
       this.GetGoodsData();
      },
      handleclose(){
          this.dialogGoods=false;
        },
      handleSelectionChange(val) {
       this.multipleSelection = val;
       this.multipleSelection.forEach(item=>{
         this.ids.push(item.goodsId);
      
         this.img.push(item.goodsPicture);
         
       })
       if(this.ids.length==1){
         this.GoodsId=this.ids.toString();
         this.handleclose();
         
       }else
       {
         this.ids=[];
         this.img=[];
       }

      },
      GetGoodsData(){
        this.$axios({
          url:"http://10.3.181.32:53590/api/Bargain/GetGoodsInfoData",
          method:"get"
        }).then((res)=>{
          this.tableData=res.data;
        
        })
      },
        next() {
        if (this.active++ > 2) this.active = 0;
      },
      detail(){
        this.Add();
         this.$router.push("/main/bargain/goods");
         
      },
       GoodsData(){
        this.$axios({
          url:"http://10.3.181.32:53590/api/Bargain/GetGoodsInfoData?id="+this.GoodsId,
          method:"get"
        }).then((res)=>{
          this.GoodsForm=res.data;
          this.ruleForm.GoodsProperty=this.GoodsForm[0].goodsId;
          this.ruleForm.CutName=this.GoodsForm[0].goodsName;
          this.ruleForm.CutImg=this.GoodsForm[0].goodsPicture;
        })
      },
      AttributeData(){
        alert(this.GoodsId);
         this.$axios({
          url:"http://10.3.181.32:53590/api/Bargain/GetAttributeData?id="+this.GoodsId,
          method:"get"
        }).then((res)=>{
          this.Attribute=res.data;
        })
      },
      FreightBind(){
         this.$axios({
          url:"http://10.3.181.32:53590/api/Bargain/FreightBind",
          method:"get"
        }).then((res)=>{
          this.options=res.data;

        })
      },
      handleSelectionChange2(val){
        
        this.ruleForm.Limited=val[0].limited;
        this.ruleForm.CutPrice=val[0].cutPrice;
      },
      Add(){
        this.ruleForm.Freight=this.value;
        this.ruleForm.LimitedResidue=this.ruleForm.Limited;
       
        this.$axios({
            url:"http://10.3.181.32:53590/api/Bargain/CutGoodsAdd",
            method:"post",
            params:this.ruleForm
          }).then((res)=>{
           if(res.data==1){
             this.$message({
               message:"添加成功",
               type:"success"
             })
           }
      
      })
      
    },
    // richText(){  
    //   editor = new E(this.$refs.editor);
    //   editor.customConfig = {
    //     onchange:function(html){
    //       this.That.Content = html
    //     },
    //     uploadImgServer: '/api/UploadImg', // 上传图片到服务器
    //     uploadFileName : 'Content', //后端使用这个字段获取图片信息
    //     uploadImgMaxLength : 1 , // 限制一次最多上传 1 张图片
    //   } 
    //   editor.create()
    // },
    active1(){
      this.next();
      this.GoodsData();
      this.AttributeData();
      this.FreightBind();
    },
    active2(){
      this.next();
      
    },
      }
      }
 </script>
 