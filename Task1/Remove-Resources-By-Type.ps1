Param (
	[Parameter(Mandatory)]
	[string] $resourceGroup,
	[string[]] $types = ("Microsoft.Web/sites","Microsoft.Sql/servers")
)

Foreach ($type in $types) {
	"Fetching resources for type: ""$type"""
	$resources = az resource list --resource-type $type --resource-group $resourceGroup -o json | ConvertFrom-Json
	"Fetched $($resources.Count) resources for type: ""$type"""
	
	Foreach ($resource in $resources) {
		"Removing resource: ""$($resource.name)"" of type: ""$($resource.type)"""
		az resource delete --ids $resource.id
		"Resource removed"
	}
}
