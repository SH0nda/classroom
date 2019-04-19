def Regist():
    blue, red = [], []
    blue = list(map(int, input().split()))
    num = int(input())
    
    while (num > 0):
        red.append(list(map(int, input().split())))
        num = num - 1
    return blue, red

def Judge(blue, red):
    crash = []
    blueX = blue[0] + blue[3]
    blueY = blue[1] + blue[2]
    for index, enemy in enumerate(red):
        enemyX = enemy[0] + enemy[3]
        enemyY = enemy[1] + enemy[2]
        if (blue[0] <= enemy[1] <= blueX and blue[1] <= enemy[0] <= blueY or
            enemy[1] <= blue[0] <= enemyY and enemy[0] <= blue[1] <= enemyX):
            crash.append(index + 1)
    return crash

def View(crash):
    for index in crash:
        print ('敵機' + str(index) + 'が当たり')

def Main():
    blue, red = Regist()
    crash = Judge(blue, red)
    View(crash)

if (__name__ == '__main__'):
    Main()
