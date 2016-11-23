﻿dataConfig = { }
excute = { }

-- 持久
dataConfig.persistent = function()
    local result = {
        -- 该扩展的应用地址
        url =
        {
            master = "Server=inernoro-new.sqlserver.rds.aliyuncs.com,3433;database=CloudPlatform;uid=inernoro;pwd=KONGque00",
            slave = "Server=inernoro-new.sqlserver.rds.aliyuncs.com,3433;database=CloudPlatform;uid=inernoro;pwd=KONGque00"
        },
        -- 该扩展的名称
        name = "sqlserver",
        -- 执行需要的参数
        data = { command },
        -- 该扩展的类型
        type = "storage",
        -- 数据类型
        dataType = "table",
        -- 执行该程序集需要的工具名称
        contentType = "Dapper",
        -- 如果配置了此，则执行入口往lua调用
        excute = excute.sqlserver,
        -- 执行成功并结束后调用，一般用于存储执行或事件回溯
        success = dataConfig.success,
        -- 执行失败后调用，可用于队列再次请求，或者记录失败日志
        error = dataConfig.error
    };
    return result;
end


-- ApiManager
dataConfig.testUrl = function()
    local host = "http://localhost:58888";
    local result = {
        url =
        {
            allInterface = "/api/services/app/Manager/AllInterface",
            interface = "/api/services/app/Manager/Interface",
            getNamespace = "/api/services/app/Manager/GetNamespace",
            loginUrl = host .. "/Account/LoginViewGet?userName={0}&password={1}",
            initUrl = host .. "/api/services/app/Manager/AllInterface",
            testHost = host,
        },
        name = "NetWord",
        data = { },
        type = "DynamicApi",
        dataType = "Json",
        contentType = "",
        success = dataConfig.success,
        error = dataConfig.error
    };
    return result;
end

dataConfig.cloudConfig = function()
	local result = {
		url = { },
        name = "cloudConfig",
        data = {
			isDebugger = true,
			--数据隔离/自动刷新
			dataIsolation = true
		 },
        type = "cloudConfig",
        dataType = "Json",
        contentType = "",
        success = dataConfig.success,
        error = dataConfig.error
	}
	return result;
end

-- 缓存
dataConfig.cache = function()
    local result = {
        url = "127.0.0.1:6380",
        name = "Redis",
        data = { key, value },
        type = "cache",
        dataType = "Json",
        contentType = "Exchange.Redis",
        success = dataConfig.success,
        error = dataConfig.error;
    };
    return result;
end

-- 搜索
dataConfig.search = function(searchKey, document)
    local result = {
        url = "http://123.56.129.104:8080/solr/",
        name = "Solr",
        data = { searchKey, document },
        type = "search",
        dataType = "XML",
        contentType = "Solr.Net",
        success = dataConfig.success,
        error = dataConfig.error
    };
    return result;
end

-- 文档
dataConfig.document = function()
    local result = {
        url = "mongodb://127.0.0.1",
        name = "Mongodb",
        data = { control, document },
        type = "document",
        dataType = "Json",
        contentType = "Mongodb.drive",
        success = dataConfig.success,
        error = dataConfig.error
    };
    return result;
end

-- Cloud Event
dataConfig.event = function(control, document)
    local result = {
        url =
        {
            localhost = "./cloudEvent",
            remote = "10.5.1.238/cloudEvent"
        },
        name = "CloudEvent",
        data = { control, document },
        type = "Event",
        dataType = "bit",
        contentType = "Windows.Server",
        success = dataConfig.success,
        error = dataConfig.error
    };
    return result;
end

-- 队列
dataConfig.queue = function(id, message)
    local result = {
        url = "ssh://123.56.132.94:Equeue.master",
        name = "Equeue",
        data = { id, message },
        type = "queue",
        dataType = "Json",
        contentType = "enode.Equeue",
        success = dataConfig.success,
        error = dataConfig.error
    };
    return result;
end

-- 消息
dataConfig.message = function()
    local result = {
        url = "ssh://123.56.132.94:Equeue.master",
        name = "SignalR",
        data = { },
        type = "message",
        dataType = "Json",
        contentType = "Microsoft.Signalr",
        success = dataConfig.success,
        error = dataConfig.error
    };
    return result;
end




dataConfig.error = function(...)
    print("error : ", os.date(), " : " .. ...);
end

dataConfig.success = function(...)
    print("successfully : " .. os.date() .. " : " .. ...);
end
 
-- print(type(os.date()));