from EEGData import EEGData
import numpy as np
from ExcelManager import ExcelManager
import matplotlib.pyplot as plt
from pprint import pprint
from FFTManager import FFTManager
from indicatorManager import indicatorManager

class Main():

     path = "C:\\Users\\김낙윤\\Desktop\\이기문_명상_1.xlsx"

     ex = ExcelManager()
     eegData = EEGData()
     fm = FFTManager()
     indicator = indicatorManager()

     list = ex.read(path)
     eegData.setData(list)

     total_meditation = 0;
     total_concentration = 0;
     avg_concentration = 0;
     avg_meditation = 0;

     concentration = []
     meditation = []

     trend_meditation = []
     trend_concentration = []

     def fft(self, sec): #sec == 0 이면 전체시간에 대한 FFT , sec는 원하는 시간 단위로 FFT 하기 위함이었으나, 샘플링레이트에 맞춰 1초로 해야하므로 일단 1로 사용함
          # SampleRate = 256
          # timeCount = 전체 시간에 대한 카운트
          timeCount = (int)(self.ex.row / 256)
          # ex) 전체시간(timeCount) 30초일때, 10초 씩 자르고 싶으면 sliceNum=3 이 됨. 7000 2000

          if not sec==0 :
               sliceNum = (int)(timeCount / sec)
               length = (int)(len(self.eegData.ch_data[0]))
               # 지정한 sec만큼 나눠서 배열로 저장
               self.concentration = np.zeros(sliceNum)
               self.meditation = np.zeros(sliceNum)
               self.trend_concentration = np.zeros(sliceNum)
               self.trend_meditation = np.zeros(sliceNum)
               max_temp1 = 0
               min_temp1 = 0
               max_temp2 = 0
               min_temp2 = 0
               for i in range(0, sliceNum):
                    for j in range(0, 8) : # 0~7번 반복(ch1~ch8)
                         min = i * (int)(length / sliceNum)
                         max = (i + 1) * (int)(length / sliceNum)
                         fftData = self.fm.fftTransform(self.eegData.ch_data[j, min:max], sec)
                         self.indicator.setData(fftData)
                         self.concentration[i] += self.indicator.concentration()
                         self.meditation[i] += self.indicator.meditation()
                    self.concentration[i] /= 8
                    self.meditation[i] /= 8
                    #print('%d초~%d초의 집중도: %f\n%d초~%d초의 명상도: %f' %(i*sec,(i+1)*sec,result_concentration[i],i*sec,(i+1)*sec,result_meditation[i]))

               #결과 출력 및 집중도와 명상도 트렌드 구하기 위하기 위해 전체구간에서의 최댓값과 최솟값 추출
               for i in range(0, sliceNum):
                    print('%2d초~%2d초의 집중도: %f' %(i*sec,(i+1)*sec, self.concentration[i]))
                    if i == 0:
                         max_temp1 = self.concentration[i]
                         min_temp1 = self.concentration[i]
                         max_temp2 = self.meditation[i]
                         min_temp2 = self.meditation[i]

                    if self.concentration[i] > max_temp1:
                         max_temp1 = self.concentration[i]
                    if min_temp1 > self.concentration[i]:
                         min_temp1 = self.concentration[i]

                    if self.meditation[i] > max_temp2 :
                         max_temp2 = self.meditation[i]
                    if min_temp2 > self.meditation[i] :
                         min_temp2 = self.meditation[i]

               for i in range(0, sliceNum):
                    print('%2d초~%2d초의 명상도: %f' % (i * sec, (i + 1) * sec, self.meditation[i]))
                    #정규화 -> (현재data - min) / (max-min) * 100
                    self.trend_concentration[i] = (self.concentration[i] - min_temp1) / (max_temp1 - min_temp1) * 100
                    self.trend_meditation[i] = (self.meditation[i] - min_temp2) / (max_temp2 - min_temp2) * 100

               # 집중도, 명상도 trend 그래프 출력 부분
               sequence = np.arange(sliceNum)
               plt.plot(sequence, self.trend_meditation)
               plt.xlabel('time(sec)')
               plt.ylabel('meditation trend(%)')
               plt.grid()
               plt.show()

               plt.plot(sequence, self.trend_concentration)
               plt.xlabel('time(sec)')
               plt.ylabel('concentration trend(%)')
               plt.grid()
               plt.show()
          else: # 샘플링레이트에 맞춰서 1초마다 FFT 해야하므로 사용되지 않음
               for i in range(0, 8):
                    fftData = self.fm.fftTransform(self.eegData.ch_data[i, :], timeCount)
                    self.indicator.setData(fftData)
                    self.total_concentration = self.total_concentration + self.indicator.concentration()
                    self.total_meditation = self.total_meditation + self.indicator.meditation()
               self.avg_concentration = self.total_concentration / 8
               self.avg_meditation = self.total_meditation / 8
               print('전체시간 평균 집중도 :', self.avg_concentration)
               print('전체시간 평균 명상도 :', self.avg_meditation)


main = Main()
#timeCount = (int)(main.ex.row / 256)
#sec = (int)(input((str)(timeCount) + "나누고 싶은 시간(초 단위)를 입력하세요(0번 입력 시, 전체시간에 대한 FFT) : "))
#if not sec == 0 :
#     while not timeCount%sec == 0:
#          print('나누어 떨어지는 수를 입력해주세요.\n')
#          sec = (int)(input((str)(timeCount) + "초를 나누고 싶은 수를 입력하세요 : "))
main.fft(1) #sample rate에 맞추기 위해 무조건 1초씩 FFT
