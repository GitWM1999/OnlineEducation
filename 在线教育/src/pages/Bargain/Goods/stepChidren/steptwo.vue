<template>
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
              @selection-change="handleSelectionChange"
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
        <el-button style="margin-top: 12px;" @click="Add()">添加</el-button>
      </div>
    </el-form>
     
</template>
<script>


export default {
    data(){
        return{
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
        value:''
        }
        
    },
    created(){
       this.GoodsData();
       this.AttributeData();
       this.FreightBind();
    },
    methods:{
      GoodsData(){
        this.GoodsId=localStorage.getItem("GoodsId");
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
          alert(JSON.stringify(this.options))
        })
      },
      handleSelectionChange(val){
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
    }
    }
}
</script>
