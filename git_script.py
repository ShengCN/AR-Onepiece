import os

gitAdd = 'git add .'
gitCommit = 'git commit -m'
gitPush = 'git push'

def gitUpdate():
    comment = raw_input("Give your comment: ")
    os.system(gitAdd)
    print 'Finish ', gitAdd

    os.system(gitCommit+'\"'+comment+'\"')
    print 'Finish', gitCommit+'\"'+comment+'\"'

    os.system(gitPush)
    print 'Finish', gitPush

if __name__ == '__main__':
    gitUpdate()