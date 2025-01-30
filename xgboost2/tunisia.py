#OnlineGDB [Python]

arr = [0,1,2,3,4,5,6,7,8,9]

result = ""
for i in range(len(arr)):
    result += str(chr(arr[i] + 96))

f = open("onlinegdb_outputfile.txt", "a")
f.write(result) 
f.close()

# cool ass white boi at 110th Precinct sometime between 1/26/25 and 1/27/25...talk to Gautier Marti 
