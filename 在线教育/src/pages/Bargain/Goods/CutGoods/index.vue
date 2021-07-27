<template>
  <!--主体-->
  <div class="table">
    <!--面包屑-->
    <div class="bao">
      <el-breadcrumb separator="/">
        <el-breadcrumb-item :to="{ path: '/' }" class="el-icon-s-unfold"
          >主页</el-breadcrumb-item
        >
        <el-breadcrumb-item>
          <a href="/">营销</a>
        </el-breadcrumb-item>
        <el-breadcrumb-item class="title">砍价管理</el-breadcrumb-item>
      </el-breadcrumb>
    </div>
    <!--a标题-->
    <div class="aTitle">
    </div>
 <el-steps :active="active" finish-status="success">
          <el-step title="选择砍价商品">
          </el-step>
          <el-step title="填写基本信息">
          </el-step>
          <el-step title="修改商品信息">
          </el-step>
        </el-steps>
    <div v-if="active == 0">
      <el-form
      ref="ruleForm"
      :model="ruleForm"
      label-width="100px"
      class="demo-ruleForm"
    >
      <div class="MesBox">
        <div class="left">
          <el-form-item label="商品轮播图">
            <img
              :src="'http://10.3.181.32:53590' + ruleForm.CutImg"
              width="100"
              height="100"
            />
          </el-form-item>

          <el-form-item label="砍价活动名称" prop="CutName">
            <el-input v-model="ruleForm.CutName"></el-input>
          </el-form-item>

          <el-form-item label="砍价活动简介" prop="CutIntro">
            <el-input v-model="ruleForm.CutIntro"></el-input>
          </el-form-item>

          <el-form-item label="单位" prop="CutUnit">
            <el-input v-model="ruleForm.CutUnit"></el-input>
          </el-form-item>
          <el-form-item class="btime" label="活动日期">
            <el-date-picker
              v-model="ruleForm.BeginTime"
              type="date"
              placeholder="开始时间"
               value-format="yyyy-MM-dd"
            ></el-date-picker>
            <span>至</span>
            <el-date-picker
              v-model="ruleForm.EndTime"
              type="date"
              placeholder="结束时间"
              value-format="yyyy-MM-dd"
            ></el-date-picker>
          </el-form-item>

          <el-form-item label="砍价人数" prop="CutPeople">
            <el-input-number
              v-model="ruleForm.CutPeople"
              :min="1"
              :max="10"  
            ></el-input-number>
          </el-form-item>

          <el-form-item label="砍价次数" >
            <el-input-number
              v-model="ruleForm.CutNumber"
              :min="1"
              :max="10"
              label="描述文字"
            ></el-input-number>
          </el-form-item>

          <el-form-item label="购买数量限制" prop="NumberLimited">
            <el-input-number
              v-model="ruleForm.Limited"
             
              :min="1"
              :max="10"
              label="描述文字"
            ></el-input-number>
          </el-form-item>
          <el-form-item label="运费模板" prop="Freight">
            <el-select v-model="Freight" placeholder="请选择">
              <el-option
                v-for="(item, i) in options"
                :key="i"
                :label="item.label"
                :value="item.value"
              ></el-option>
            </el-select>
          </el-form-item>

          <el-form-item label="活动状态">
            <el-radio v-model="ruleForm.BargainState" :label="0">关闭</el-radio>
            <el-radio v-model="ruleForm.BargainState" :label="1">开启</el-radio>
          </el-form-item>
          <el-form-item label="商品属性">
            <el-table
              :data="tableData"
              border
              style="width: 80000px"
            >
              <el-table-column type="selection" width="55"></el-table-column>
              <el-table-column label="图片" width="180">
                <template slot-scope="scope">
                  <img
                    :src="'http://10.3.181.32:53590' + scope.row.Picture"
                    width="60"
                    height="60"
                  />
                </template>
              </el-table-column>

              <el-table-column label="砍价金额" width="220">
                 <template slot-scope="scope">
                   <el-input-number v-model="scope.row.CutPrice"  @change='handleChangeCutPrice' :min="0" :step="0.1" :max="10" label="描述文字"></el-input-number>

                </template>
              </el-table-column>
              <el-table-column label="成本价">
                <template slot-scope="scope">
                  <span>{{ scope.row.CostPrice }}</span>
                </template>
              </el-table-column>
              <el-table-column label="原价">
                <template slot-scope="scope">
                  <span>{{ scope.row.OriginalPrice }}</span>
                </template>
              </el-table-column>
              <el-table-column label="库存">
                <template slot-scope="scope">
                  <span>{{ scope.row.Inventory }}</span>
                </template>
              </el-table-column>
              <el-table-column label="限量" width="220">
                <template slot-scope="scope">
              <el-input-number
                    v-model="scope.row.LimitedResidue"
                   :min='0'
                    :step="1"
                    @change='handleChangeLimitedResidue'
                  ></el-input-number>
                </template>
                  
              </el-table-column>

              <el-table-column label="重量">
                <template slot-scope="scope">
                  <span>{{ scope.row.Weight }}</span>
                </template>
              </el-table-column>
              <el-table-column label="体积">
                <template slot-scope="scope">
                  <span>{{ scope.row.Bulk }}</span>
                </template>
              </el-table-column>
              <el-table-column label="商品编号">
                <template slot-scope="scope">
                  <span>{{ scope.row.GoodsNum }}</span>
                </template>
              </el-table-column>
              <el-table-column prop="GoodsProperty" label></el-table-column>
            </el-table>
          </el-form-item>
        </div>
      </div>
    </el-form>
    </div>
    <div v-if="active == 1">
      <quill-editor ref="text" v-model="ruleForm.CutIntro" class="myQuillEditor" style="height:400px;" @change="onchange($event)" />
    </div>
    <div v-if="active == 2">
      
    </div>

     <div v-if="this.active==0">
      <el-button style="margin-top: 80px;background: #3a8ee6;color: #fff;margin-left:30px;" @click="next">下一步</el-button>
      </div>

      <div v-if="this.active==2">
      <el-button style="margin-top: 20px;background: #3a8ee6;color: #fff;margin-left:30px;" @click="prev">上一步</el-button> 
      <el-button style="margin-top: 20px;background: #3a8ee6;color: #fff;margin-left:30px;" @click="go">提交</el-button>
      </div>

      <div v-if="this.active==1">
        <el-button style="margin-top: 80px;background: #3a8ee6;color: #fff;margin-left:30px;" @click="prev">上一步</el-button>
        <el-button style="margin-top: 80px;background: #3a8ee6;color: #fff;margin-left:30px;" @click="next">下一步</el-button>
      </div>

     
    <!--主体尾-->
  </div>
</template>

<script>
import axios from "axios";
import { mapMutations, mapState } from "vuex";
// import { quillEditor } from "vue-quill-editor";
// import "quill/dist/quill.core.css";
// import "quill/dist/quill.snow.css";
// import "quill/dist/quill.bubble.css";
export default {
  data() {
    return {
      tableData: [],
      active: 0,
      dialogVisible: false,
      Freight: "",
      options: [
        {
          value: "1",
          label: "包邮"
        },
        {
          value: "0",
          label: "不包邮"
        }
      ],
      ruleForm1: [],
      ruleForm: {
        CutImg: "",
        CutName: "",
        CutIntro: "",
        CutUnit: "",
        BeginTime: "",
        EndTime: "",
        CutPeople: 0,
        CutNumber: 0,
        Limited: 0,
        Freight: "",
        BargainState: 0,
        GoodsProperty: 0,
        CutPrice: 0
      }
      
    };
  },
  watch:{
ruleForm (val){
  console.log(val);
}
  },
  computed: {
    ...mapState("table", {
      list: state => state.list
    })
  },
  created() {
    (this.ruleForm1 = JSON.parse(localStorage.getItem("trip1"))) //取
      console.log(this.ruleForm1);
    this.ruleForm.CutImg = this.ruleForm1[0].Goods_img;
    this.ruleForm.CutUnit = this.ruleForm1[0].Goods_unit;
    this.ruleForm.GoodsProperty = this.ruleForm1[0].Goods_id;

    this.getAttributes();
  },
  methods: {
    handleChangeLimitedResidue(val
    ){
     
       this.ruleForm={...this.ruleForm}
        this.ruleForm.Limited=val
    },
    handleChangeCutPrice(val){
      
      
      this.ruleForm={...this.ruleForm}
      this.ruleForm.CutPrice=val
      alert(this.ruleForm.CutPrice);
    },
    //上一步
      prev()
      {
        //上一步
        if(this.active==0)
        {
          this.active==0;
        }else
        {
          this.active-=1;
        }
      },
      //下一步
      next() {
        if(this.active==2)
        {
          this.goodsGuiGe=="包邮";
        }
        
        if (this.active++ > 2) this.active = 0;
      },
      go()
      {   

          this.ruleForm.Freight=this.Freight;

          this.$axios
          .post("http://10.3.181.32:53590/api/CutGoods/AddCutGoods", this.ruleForm)
          .then(res => {
            if (res.data.data > 0) {
              this.$message({
                message: "添加成功",
                type: "success"
              });
              this.resetForm();
              this.dialogVisible = false;
            }
          });

      },
    getAttributes() {
      axios({
        url:
          "http://10.3.181.32:53590/api/CutGoods/ShowGoodsProp?goods_id=" +
          this.ruleForm.GoodsProperty +
          "",
        method: "get"
      }).then(res => {
        res.data.data[0].CutPrice=0
        res.data.data[0].LimitedResidue=0
        this.tableData = [...res.data.data];
        console.log(this.tableData);
      });
    },
    onchange(event){

      this.ruleForm.CutIntro=event.text.slice(0,event.text.length-1);
    }
  }
};
</script>

<style scoped>
.name {
  width: 150px;
}
.add {
  margin-left: 10px;
}

.el-breadcrumb {
  width: 100%;
  line-height: 33px;
}
.el-breadcrumb__item {
  line-height: 3;
}
.bao {
  padding-left: 20px;
  border-bottom: solid 1px gainsboro;
}
.table {
  min-height: calc(100vh - 50px);
  padding: 20px;
  position: relative;
  height: 100%;
  width: 100%;
  background-color: rgba(187, 202, 202, 0.12);
  overflow-y: auto;
}
.box-shadow {
  width: 95%;
  height: 90%;
  margin-left: 2.5%;
  box-shadow: 0 0 6px rgba(160, 166, 166, 0.41);
  background-color: rgba(187, 202, 202, 0.12);
}
.aTitle {
  border-bottom: solid 1px gainsboro;
  line-height: height;
  padding-bottom: 5px;
  padding-top: 5px;
  background-color: rgba(187, 202, 202, 0.12);
}
.aWare {
  text-decoration: none;
  color: skyblue;
  padding-left: 20px;
}
.pageing {
  border-bottom: solid 1px gainsboro;
  padding-top: 3px;
  padding-bottom: 3px;
  line-height: height;
  margin-top: 15px;
  background-color: white;
}
.spanMargin {
  margin-left: 45px;
}
.bottonA {
  line-height: height;
  padding-top: 10px;
  padding-bottom: 10px;
  background-color: rgba(187, 202, 202, 0.12);
}
</style>
