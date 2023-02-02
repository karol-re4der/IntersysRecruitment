function fixage(arr) {
    var result = ''
    for (var i = 0; i < arr.length; i++) {
        if (arr[i] >= 18 && arr[i] <= 60) {
            if (result !== '') {
                result += ','
            }
            result += arr[i]
        }
    }

    if (result === '') {
        return 'NA'
    }

    return result
}

//For testing
//var result = fixage([5, 15, 25, 78, 59, 45])
//console.log(result)
//result = fixage([18, 3, 30, 22, 11, 60])
//console.log(result)
//result = fixage([1, 3, 3, 2, 11, 6])
//console.log(result)
//result = fixage([])
//console.log(result)