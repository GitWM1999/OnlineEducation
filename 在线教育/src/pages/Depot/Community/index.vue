<template>

  
    <div style="width:100%">
    <el-form>
        <el-select v-model="value" clearable placeholder="请选择">
    <el-option
      v-for="item in options"
      :key="item.value"
      :label="item.depoName"
      :value="item.depotID">
    </el-option>
  </el-select>
  <el-button type="primary" @click="query()">查询</el-button>
    </el-form>
          <el-table
      :data="tableData">
      <el-table-column
        prop="communtiyName"
        label="小区名称">
      </el-table-column>
      <el-table-column
        prop="colonelName"
        label="团长">
      </el-table-column>
      <el-table-column
        prop="colonelPhone"
        label="电话">
      </el-table-column>
      <el-table-column
        prop="communtiyPath"
        label="路线">
      </el-table-column>
      <el-table-column
        prop="communtiyAddress"
        label="地址">
      </el-table-column>
      <el-table-column label="操作">
           <template slot-scope="scope">
             <el-button type="primary" icon="el-icon-edit" circle @click="BackFill(scope.row)"></el-button>
       <el-button type="danger" icon="el-icon-delete" circle @click="DepotDel(scope.row)"></el-button>
           </template>
      </el-table-column>
    </el-table>
    <el-pagination
    @current-change="handlePageChange"
    @size-change="handleSizeChange"
    :current-page="currentpage"
    :page-size="size"
  background
  layout="prev, pager, next"
  :total="totalcount">
</el-pagination>
    </div>
</template>
<script>
    export default {
      data() {
        return {
          tableData:[],
          options: [],
          value: '',
          currentpage:1,
          size:2,
          totalcount:0
        }
      },
      created(){
          this.GetList();
          this.Bind();
      },
      methods:{
          GetList(val){
          this.$axios.get("http://10.3.181.32:53590/api/Community/CommunityData?depotID="+val+"&currentpage="+this.currentpage+"&size="+this.size).then((res)=>
          {
               
              this.tableData=res.data.data;
              alert(JSON.stringify(this.tableData));
              this.totalcount=res.data.totalcount;
              
          })
          },
          Bind(){
              this.$axios.get("http://10.3.181.32:53590/api/Community/DepotBind").then(res=>{
                  this.options=res.data;
              })
          },
          query(){
              this.GetList(this.value)
          },
          handlePageChange(val){
            this.currentpage=val;
            this.GetList();
          },
          handleSizeChange(val){
            this.size=val;
            this.GetList();
          }
      }
    }
  </script>