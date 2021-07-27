<template>

<div style="width:100%">
  <el-form>
  <el-button type="primary" class="el-icon-plus" @click="Add()">新增</el-button>
  </el-form>
  <el-table
    :data="tableData"
    border
    style="width: 100%">
    <el-table-column
      prop="depotID"
      label="ID"
      width="180">
    </el-table-column>
    <el-table-column
      prop="depoName"
      label="名称"
      width="180">
    </el-table-column>
    <el-table-column
      prop="depotAddress"
      label="地址">
    </el-table-column>
    
    <el-table-column
      prop="nautica"
      label="坐标">
    </el-table-column>
    
    <el-table-column
      prop="colonelNumber"
      label="商品数量">
    </el-table-column>
    <el-table-column
      prop="status"
      label="状态">
      <template slot-scope="scope">
          <el-switch v-model="scope.row.status">
          </el-switch>
      </template>
    </el-table-column>
    <el-table-column label="操作">
    <template slot-scope="scope2">
       <el-button type="primary" icon="el-icon-edit" circle @click="BackFill(scope2.row)"></el-button>
       <el-button type="danger" icon="el-icon-delete" circle @click="DepotDel(scope2.row)"></el-button>
     
    </template>
    </el-table-column>
  </el-table>
  <el-pagination
      @current-change="handlePageChange"
      @size-change="handleSizeChange"
      :current-page="currentpage"
      :page-size="size"
      background
      layout="prev,pager,next"
      :total="totalcount" >
    </el-pagination>
    <el-dialog
    title="新增"
    :visible.sync="dialogVisible"
    width="50%"
    :before-close="handleclose"
    >
    <el-form :model="depot">
    <el-form-item label="仓库名称">
      <el-input v-model="depot.DepoName"></el-input>
    </el-form-item>
    <el-form-item label="联系人姓名">
      <el-input v-model="depot.LinkName"></el-input>
    </el-form-item>
    <el-form-item label="联系电话">
      <el-input v-model="depot.LinkPhone"></el-input>
    </el-form-item>
    <!-- <el-form-item label="仓库地址">
      <el-input v-model="depot.DepotAddress"></el-input>
    </el-form-item>
    <el-form-item label="经纬度">
      <el-input v-model="depot.Nautica"></el-input>
    </el-form-item> -->
    <el-form>
    <el-row :gutter="24">
      <el-col :span="12">
        <el-col :span="12">
          <el-form-item label="位置经度" prop="lng">
            <el-input v-model="depot.lng" type="number" class="input_number" @mousewheel.native.prevent />
          </el-form-item>
        </el-col>
        <el-col :span="12">
          <el-form-item label="位置维度" prop="lat">
            <el-input v-model="depot.lat" type="number" class="input_number" @mousewheel.native.prevent />
          </el-form-item>
        </el-col>
        <el-col :span="24">
          <baidu-map class="bm-view" ak="QFgFQorrB84maOZh0pPGC8kUiP0mGIhx" :center="center" :zoom="zoom" :scroll-wheel-zoom="true" @ready="createMap" >
            <!-- 搜索-->
            <bm-local-search :keyword="depot.DepotAddress" :auto-viewport="true" style="display: none"></bm-local-search>
            <!-- 标记-->
            <bm-marker-clusterer>
              <bm-marker :position="{lng: depot.lng, lat: depot.lat}"/>
            </bm-marker-clusterer>
          </baidu-map>
          <el-input v-model="depot.DepotAddress" placeholder="搜索地点" style="margin-left: 10px;width: 200px;position: absolute;top: 25%;opacity: 0.9" prefix-icon="el-icon-search"></el-input>
        </el-col>
      </el-col>
    </el-row>
  </el-form>
    <el-form-item label="状态">
      <el-switch
      v-model="depot.Status"
      >
      </el-switch>
    </el-form-item>
    </el-form>
    <span slot="footer" >
       <el-button type="primary" @click="DepotAdd()">添加</el-button>
       <el-button @click="dialogVisible=false">取消</el-button>
    </span>
    
    </el-dialog>
     <el-dialog
    title="修改"
    :visible.sync="dialogEditVisible"
    width="50%"
    :before-close="handleEditclose"
    >
    <el-form :model="BackFillFrom">
    <el-form-item label="仓库名称">
      <el-input v-model="BackFillFrom.depoName"></el-input>
    </el-form-item>
<el-form>
    <el-row :gutter="24">
      <el-col :span="12">
        <el-col :span="12">
          <el-form-item label="位置经度" prop="lng">
            <el-input v-model="depot.lng" type="number" class="input_number" @mousewheel.native.prevent />
          </el-form-item>
        </el-col>
        <el-col :span="12">
          <el-form-item label="位置维度" prop="lat">
            <el-input v-model="depot.lat" type="number" class="input_number" @mousewheel.native.prevent />
          </el-form-item>
        </el-col>
        <el-col :span="24">
          <baidu-map class="bm-view" ak="QFgFQorrB84maOZh0pPGC8kUiP0mGIhx" :center="center" :zoom="zoom" :scroll-wheel-zoom="true" @ready="createMap" >
            <!-- 搜索-->
            <bm-local-search :keyword="BackFillFrom.depotAddress" :auto-viewport="true" style="display: none"></bm-local-search>
            <!-- 标记-->
            <bm-marker-clusterer>
              <bm-marker :position="{lng: depot.lng, lat: depot.lat}"/>
            </bm-marker-clusterer>
          </baidu-map>
          <el-input v-model="BackFillFrom.depotAddress" placeholder="搜索地点" style="margin-left: 10px;width: 200px;position: absolute;top: 25%;opacity: 0.9" prefix-icon="el-icon-search"></el-input>
        </el-col>
      </el-col>
    </el-row>
  </el-form>
    
    <el-form-item label="状态">
      <el-switch
      v-model="BackFillFrom.status"
      >
      </el-switch>
    </el-form-item>
    </el-form>
    <span slot="footer" >
       <el-button type="primary" @click="DepotEdit()">修改</el-button>
       <el-button @click="dialogEditVisible=false">取消</el-button>
    </span>
    
    </el-dialog>
    </div>
</template>

<script>
  import BaiduMap from 'vue-baidu-map/components/map/Map.vue'
  //标记点
  import BmMarkerClusterer from 'vue-baidu-map/components/extra/MarkerClusterer'
  //搜索
  import BmLocalSearch from 'vue-baidu-map/components/search/LocalSearch.vue'
  export default 
  {
     components: { 
      BaiduMap,
      BmMarkerClusterer,
      BmLocalSearch
    },
    data() {
      

      return {
        
            tableData:[],
            currentpage:1,
            size:2,
            totalcount:0,
            dialogVisible:false,
            dialogEditVisible:false,
            depot:{
               DepotID:0,
               DepoName:"",
               LinkName:"",
               LinkPhone:"",
               DepotAddress:"",
               lng:"",
               lat:"",
               Nautica:"",
               Status:true,
               ColonelNumber:0
            },
             BackFillFrom:{},
              center: { lng: 0, lat: 0},
             zoom: 10,
              model: { 
              lng: '',
              lat: '',
              address: ''
          }
      }
            
        },
       created(){
            this.getList()
        },
        methods:{
        getList(){
            this.$axios.get("http://10.3.181.32:53590/api/Depot/DepotGetData?currentpage="+this.currentpage+"&size="+this.size).then((res)=>
            {
                this.tableData=res.data.data;
                this.totalcount=res.data.totalcount;
            })
        },
        
        handlePageChange(val){
           this.currentpage=val;
           this.getList();
        },
        handleSizeChange(val){
          this.size=val;
          this.getList();
        },
       
        handleclose(){
          this.dialogVisible=false;
        },
        handleEditclose(){
          this.dialogEditVisible=false;
        },
        //打开添加对话框
        Add(){
          this.dialogVisible=true;
        },
        //添加
        DepotAdd(){
            this.$axios({
            url:"http://10.3.181.32:53590/api/Depot/DepotAdd",
            method:"post",
            params:this.depot
          }).then((res)=>{
            if(res.data>0){
              this.$message({
                message:'添加成功',
                type:'success'
              })
              window.location.reload();
              this.dialogVisible=false;
            }
          })
        },
        //删除
        DepotDel(row){
            alert(JSON.stringify(row.depotID) );
            this.$confirm('删除这条数据,是否继续?','提示',{
              confirmButtonText:'确定',
              cancelButtonText:'取消',
              type:'warning'
            }).then(()=>{
              this.$axios.post("http://10.3.181.32:53590/api/Depot/DepotDel?id="+row.depotID).then(res=>{
                if(res.data=="1"){
                  this.$message({
                    type:'success',
                    message:'删除成功!'
                  });
                   window.location.reload();
                }
              })
            })
        },
        //反填
        BackFill(row){
         
          this.BackFillFrom=row;
           alert(JSON.stringify(this.BackFillFrom));
          this.dialogEditVisible=true;

        },
        DepotEdit(){
          this.$axios({
            url:"http://10.3.181.32:53590/api/Depot/DepotEdit",
            method:"post",
            params:this.BackFillFrom
            
          }).then((res)=>{
            if(res.data>0){
              this.$message({
                message:'修改成功',
                type:'success'
              })
              window.location.reload();
            }
          })
        }, 
         createMap ({ BMap, map}) { 
        // 百度地图API功能
        this.center.lng = 117.2
        this.center.lat = 34.26
        //this.zoom = this.zoom
        this.map2 = map
        const viewthis = this
        map.addEventListener('click', function (e) { 
          viewthis.depot.lng = e.point.lng
          viewthis.depot.lat = e.point.lat
        })

        // 区域图
        var datas = new Array('徐州市-#665599')
        var bdary = new BMap.Boundary()
        for (var i = 0; i < datas.length; i++) { 
          getBoundary(datas[i], bdary)
        }

        // 设置区域图
        function getBoundary (data, bdary) { 
          data = data.split('-')
          bdary.get(data[0], function (rs) { 
            // 获取行政区域
            var count = rs.boundaries.length // 行政区域的点有多少个
            // var pointArray = []
            for (var i = 0; i < count; i++) { 
              var ply = new BMap.Polygon(rs.boundaries[i], { 
                strokeWeight: 2,
                strokeColor: '#ff0000',
                fillOpacity: 0.1,
                fillColor: data[1]
              }) // 建立多边形覆盖物
              map.addOverlay(ply) // 添加覆盖物
            }
          })
        }
    }
    }
  }
</script>
<style>
.avatar-uploader .el-upload {
  border: 1px dashed #d9d9d9;
  border-radius: 6px;
  cursor: pointer;
  position: relative;
  overflow: hidden;
}
.avatar-uploader .el-upload:hover {
  border-color: #409eff;
}
.avatar-uploader-icon {
  font-size: 28px;
  color: #8c939d;
  width: 178px;
  height: 178px;
  line-height: 178px;
  text-align: center;
}
.avatar {
  width: 178px;
  height: 178px;
  display: block;
}
 .bm-view { 
    width: 100%;
    height: 300px;
  }
</style>